namespace Backend.DTOs;

public class CreateContactDto
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required DateOnly BirthDate { get; set; }
    public required string Password { get; set; }
    public Guid CategoryId { get; set; }

    public string? SubcategoryName { get; set; }
    public Guid? SubcategoryId { get; set; }
}