using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/subcategory")]
public class SubcategoryController : ControllerBase
{
    private readonly ISubcategoryService _subcategoryService;

    public SubcategoryController(ISubcategoryService subcategoryService)
    {
        _subcategoryService = subcategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subcategoriesList = await _subcategoryService.GetAll();
        return Ok(new {subcategories = subcategoriesList});
    }
}