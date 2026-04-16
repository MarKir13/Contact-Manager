using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Contact
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Surname { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Email { get; set; }

    [Required]
    [MaxLength(72)] // 72 is the max length of hashes while using BCrypt encryption
    public required string PasswordHash { get; set; }

    [Required]
    [MaxLength(15)]
    public required string PhoneNumer { get; set; }

    public required DateOnly BirthDate { get; set; }

    [MaxLength(50)]
    public string? SubcategoryName { get; set; }
    
    public Guid CategoryId { get; set; }
    public Guid? SubcategoryId { get; set; }

    public Category Category { get; set; }
    public Subcategory? Subcategory { get; set; }


}