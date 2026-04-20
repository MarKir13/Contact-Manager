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

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var contactDetails = await _contactService.GetById(id);
            return Ok(new {contact = contactDetails});
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new {message = ex.Message});
        }
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        try
        {
            await _contactService.DeleteById(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new {message = ex.Message});
        }
    }
}