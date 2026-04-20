namespace Backend.DTOs;

public class GetContactSummaryDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }

}