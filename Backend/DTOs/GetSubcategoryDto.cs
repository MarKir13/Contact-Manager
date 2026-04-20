namespace Backend.DTOs;

public class GetSubcategoryDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}