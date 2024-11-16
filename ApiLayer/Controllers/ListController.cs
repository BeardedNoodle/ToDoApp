
using ApiLayer.Services;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers;

[ApiController]
[Route("api/list")]
public class ListController : ControllerBase
{
    private readonly ListService _service;
    public ListController(ListService service)
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
    public async Task<IActionResult> CreateUser(ListCreateModel model, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(model);
        return Ok(result);
    }
}