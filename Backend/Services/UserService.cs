using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly TokenProvider _tokenProvider;

    public UserService(AppDbContext context, TokenProvider tokenProvider)
    {
        _context = context;
        _tokenProvider = tokenProvider;
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

    public async Task<string> Login(LoginDto dto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == dto.Username);
        if (user == null)
        {
            throw new ArgumentException("Nieprawidłowy login lub hasło");
        }

        bool password_verify = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
        if (!password_verify)
        {
            throw new ArgumentException("Nieprawidłowy login lub hasło");
        }

        string token = _tokenProvider.CreateToken(user);
        return token;
    }
}