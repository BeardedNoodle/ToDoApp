
using ApiLayer.Services;
using ApiLayer.Services.Base;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public async Task<IActionResult> CreateUser(ListCreateModel model, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(model);
        return result.IsSuccess ? Ok(result.Data) : result.Error.ToProblemDetails();
    }
}