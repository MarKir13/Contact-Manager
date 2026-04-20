using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class ContactService : IContactService
{
    private readonly AppDbContext _context;

    public ContactService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(CreateContactDto dto)
    {
        //we are checking if contact with such email and phone number exists
        bool exists = await _context.Contacts.AnyAsync(c => c.Email == dto.Email);
        if (exists)
        {
            throw new ArgumentException("Kontakt o takim emailu juz istnieje");
        }

        string password_hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var contact = new Contact
        {
          Id = Guid.NewGuid(),
          Name = dto.Name,
          Surname = dto.Surname,
          PhoneNumber = dto.PhoneNumber,
          Email = dto.Email,
          PasswordHash = password_hash,
          BirthDate = dto.BirthDate,
          CategoryId = dto.CategoryId,
          SubcategoryId = dto.SubcategoryId,
          SubcategoryName = dto.SubcategoryName 
        };

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<GetContactSummaryDto>> GetAll()
    {
        var contacts = _context.Contacts.Select(c => new GetContactSummaryDto
        {
            Id = c.Id,
            Name = c.Name,
            Surname = c.Surname,
            PhoneNumber = c.PhoneNumber,
            Email = c.Email
        }).ToList();

        return contacts;
    }

    public async Task<GetContactDetailsDto> GetById(Guid Id)
    {
        var contact = _context.Contacts.Include(c => c.Category).Include(c => c.Subcategory).FirstOrDefault(c => c.Id == Id);
        if(contact == null)
        {
            throw new KeyNotFoundException("Nie znaleziono takiego kontaktu");
        }

        string subcategoryName = contact.SubcategoryName;
        if (subcategoryName == null && contact.Subcategory != null)
        {
            subcategoryName = contact.Subcategory.Name;
        }

        var contactDetails = new GetContactDetailsDto
        {
          Id = contact.Id,
          Name = contact.Name,
          Surname = contact.Name,
          BirthDate = contact.BirthDate,
          PhoneNumber = contact.PhoneNumber,
          Email = contact.Email,
          CategoryName = contact.Category.Name,
          SubcategoryName = subcategoryName
        };

        return contactDetails;
    }
}