using DataLayer.Mongo.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ServiceLayer.MongoService;
using System.ComponentModel;
using System.Text;

namespace ToDoApp.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly MongoDbContext _context;

    public UserController(MongoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        var userCollections = _context.Users;
        var users = await userCollections.Find(_ => true).ToListAsync();
        return Ok(users);
    }

    [HttpGet("get-by-id")]
    public IActionResult GetByIdAsync([FromQuery] long id)
    {
        return Ok($"{id}: is id");
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user, CancellationToken cancellationToken){
        await _context.Users.InsertOneAsync(user);
        return Ok();
    }

}
