using DataLayer.Models;
using MongoDB.Driver;
using ServiceLayer.MongoService;
using DataLayer.Mappers;
using MongoDB.Bson;
namespace ApiLayer.Services;

public class UserService
{

    private readonly MongoDbContext _context;

    public UserService(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<UserModel> CreateAsync(UserCreateModel model)
    {
        var user = model.ToEntity();
        await _context.Users.InsertOneAsync(user);
        return user.ToModel();
    }

    public async Task<UserModel> GetByIdAsync(string id)
    {
        var userCollections = _context.Users;
        var users = await userCollections.Find(x => x.Id.Equals(ObjectId.Parse(id))).FirstOrDefaultAsync();

        return users.ToModel();
    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        var userCollections = _context.Users;
        var users = await userCollections.Find(_ => true).ToListAsync();

        return users.ToModelList();
    }
}
