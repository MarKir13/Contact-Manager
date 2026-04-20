namespace Backend.DTOs;

public class GetContactDetailsDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateOnly BirthDate { get; set;}
    public required string CategoryName { get; set; }
    public string? SubcategoryName { get; set; }
}