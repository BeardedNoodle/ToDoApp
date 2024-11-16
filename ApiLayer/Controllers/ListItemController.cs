using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLayer.Services;
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
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(ListItemCreateModel model, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(model);
        return Ok(result);
    }
}
