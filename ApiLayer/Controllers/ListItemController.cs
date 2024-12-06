using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLayer.Services;
using ApiLayer.Services.Base;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers;

[ApiController]
[Route("api/list/item")]
public class ListItemController : ControllerBase
{
    private readonly ListItemService _service;

    public ListItemController(ListItemService listItemService)
    {
        _service = listItemService;
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
    public async Task<IActionResult> CreateUser(ListItemCreateModel model, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(model);
        return result.IsSuccess ? Ok(result.Data) : result.Error.ToProblemDetails();
    }
}
