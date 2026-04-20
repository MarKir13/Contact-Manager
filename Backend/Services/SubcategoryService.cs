using Backend.Data;
using Backend.DTOs;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class SubcategoryService : ISubcategoryService
{
    private readonly AppDbContext _context;

    public SubcategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetSubcategoryDto>> GetAll()
    {
        var subcategories = _context.Subcategories.Select(s => new GetSubcategoryDto
        {
            Id = s.Id,
            Name = s.Name
        }).ToList();

        return subcategories;
    }
}