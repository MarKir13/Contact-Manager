using Backend.DTOs;

namespace Backend.Services.Interfaces;

public interface IContactService
{
    public Task<bool> Create(CreateContactDto dto);
    public Task<List<GetContactSummaryDto>> GetAll();
    public Task<GetContactDetailsDto> GetById(Guid Id);
}