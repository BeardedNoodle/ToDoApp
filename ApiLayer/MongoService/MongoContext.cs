using DataLayer.Mongo.Entity;
using MongoDB.Driver;

namespace ServiceLayer.MongoService;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDB");
        var mongoClient = new MongoClient(connectionString);
        _database = mongoClient.GetDatabase("TODO");
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

    public IMongoCollection<List> Lists => _database.GetCollection<List>("List");

    public IMongoCollection<ListItem> ListItems => _database.GetCollection<ListItem>("ListItems");

    public IMongoCollection<Follower> Followers => _database.GetCollection<Follower>("Users");

}

