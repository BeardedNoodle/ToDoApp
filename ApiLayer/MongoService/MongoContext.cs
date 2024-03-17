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
        _database = mongoClient.GetDatabase("TODOO");
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    
    public IMongoCollection<List> Lists => _database.GetCollection<List>("Users");
    
    public IMongoCollection<ListItem> ListItems => _database.GetCollection<ListItem>("Users");
    
    public IMongoCollection<Follower> Followers => _database.GetCollection<Follower>("Users");

}

