namespace Backend.DTOs;

public class GetCategoryDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}