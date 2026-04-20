using Backend.DTOs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            await _userService.Register(dto);
            return Created("", null);
        }
        catch(ArgumentException ex)
        {
            return BadRequest(new {message = ex.Message});
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            string jwt_token = await _userService.Login(dto);
            return Ok(new {token = jwt_token});
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new {message = ex.Message});     
        }
    }
}