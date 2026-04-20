using Backend.Data;
using Backend.DTOs;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetCategoryDto>> GetAll()
    {
        var categories = await _context.Categories.Select(c => new GetCategoryDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToListAsync();

        return categories;
    }
}