using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class User
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Username { get; set; }
    [Required]
    [MaxLength(72)] // 72 is the max length of hashes while using BCrypt encryption
    public required string PasswordHash { get; set; }
}