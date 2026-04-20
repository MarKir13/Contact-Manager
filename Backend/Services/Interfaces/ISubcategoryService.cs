using Backend.DTOs;

namespace Backend.Services.Interfaces;

public interface ISubcategoryService
{
    public Task<List<GetSubcategoryDto>> GetAll();
}