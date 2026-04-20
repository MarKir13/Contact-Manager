using Backend.DTOs;

namespace Backend.Services.Interfaces;

public interface ICategoryService
{
    public Task<List<GetCategoryDto>> GetAll();
}