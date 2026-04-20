using Backend.DTOs;

namespace Backend.Services.Interfaces;

public interface IContactService
{
    public Task<bool> Create(CreateContactDto dto);
    public Task<List<GetContactSummaryDto>> GetAll();
    public Task<GetContactDetailsDto> GetById(Guid Id);
    public Task<bool> DeleteById(Guid Id);
    public Task<bool> Update(Guid Id, UpdateContactDto dto);
}