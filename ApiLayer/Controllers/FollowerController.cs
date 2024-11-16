using ApiLayer.Services;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers;

[ApiController]
[Route("api/follower")]
public class FollowerController : ControllerBase
{
    private readonly FollowerService _service;

    public FollowerController(FollowerService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(FollowerCreateModel model, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(model);
        return Ok(result);
    }

}
