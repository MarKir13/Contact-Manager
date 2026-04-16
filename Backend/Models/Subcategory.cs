using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Subcategory
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
}