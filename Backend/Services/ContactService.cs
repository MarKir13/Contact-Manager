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
}