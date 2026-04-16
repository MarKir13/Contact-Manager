using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Category
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
}