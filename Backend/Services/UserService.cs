using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Register(RegisterDto dto)
    {
        if(await _context.Users.AnyAsync(u => u.Username == dto.Username))
        {
            throw new ArgumentException("Taka nazwa użytkownika jest już zajęta.");
        }

        var password_hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = dto.Username,
            PasswordHash = password_hash
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return true;
    }
}