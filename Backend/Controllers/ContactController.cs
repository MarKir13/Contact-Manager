using Backend.DTOs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/contact")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreateContactDto dto)
    {
        try
        {
            await _contactService.Create(dto);
            return Created("", null);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new {message = ex.Message});
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contactList = await _contactService.GetAll();
        return Ok(new { contacts = contactList});
    }
}