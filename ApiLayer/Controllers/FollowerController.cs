using ApiLayer.Services;
using ApiLayer.Services.Base;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
        var result = await _service.GetAllAsync();
        return result.IsSuccess ? Ok(result.Data) : result.Error.ToProblemDetails();
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result.Data) : result.Error.ToProblemDetails();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(FollowerCreateModel model, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(model);
        return result.IsSuccess ? Ok(result.Data) : result.Error.ToProblemDetails();
    }

}
