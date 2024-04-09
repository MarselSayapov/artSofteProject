using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace ProfileApi.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private IUserService _userService; 
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [Route("getById")]
    [HttpGet]
    [ProducesResponseType<User>(200)]
    public async Task<IActionResult> GetUserById(uint id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }
    [Route("getAllUsers")]
    [HttpGet]
    [ProducesResponseType<User[]>(200)]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
}