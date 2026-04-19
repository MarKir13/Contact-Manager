using Backend.DTOs;

namespace Backend.Services.Interfaces;

public interface IUserService
{
    public Task<bool> Register(RegisterDto dto);
    public Task<string> Login(LoginDto dto);
}