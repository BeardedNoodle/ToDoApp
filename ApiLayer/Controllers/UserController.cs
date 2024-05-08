using ApiLayer.Services;
using DataLayer.Mappers;
using DataLayer.Models;
using DataLayer.Mongo.Entity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.MongoService;

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
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] string id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserCreateModel user, CancellationToken cancellationToken)
    {
        var result = await _userService.CreateAsync(user);
        return Ok(result);
    }

}
