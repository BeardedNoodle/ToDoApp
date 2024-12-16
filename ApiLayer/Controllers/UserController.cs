using ApiLayer.Services;
using ApiLayer.Services.Base;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {

        var result = await _userService.GetAllAsync();
        return result.IsSuccess ? Ok(result.Data) : result.Error.ToProblemDetails();
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var result = await _userService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result.Data) : result.Error.ToProblemDetails();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserCreateModel user, CancellationToken cancellationToken)
    {
        var result = await _userService.CreateAsync(user);
        return result.IsSuccess ? Ok(result.Data) : result.Error.ToProblemDetails();
    }

}
