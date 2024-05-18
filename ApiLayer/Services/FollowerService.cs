
using DataLayer.Mappers;
using DataLayer.Models;
using DataLayer.Mongo.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using ServiceLayer.MongoService;

namespace ApiLayer.Services;

public class FollowerService
{
    private readonly IMongoCollection<Follower> _collection;
    public FollowerService(MongoDbContext db)
    {
        _collection = db.Followers;
    }

    public async Task<FollowerModel> CreateAsync(FollowerCreateModel model, CancellationToken cancellationToken = default)
    {
        var entity = model.ToEntity();
        await _collection.InsertOneAsync(entity, null, cancellationToken);
        return entity.ToModel();
    }

    public async Task<List<FollowerModel>> GetByFollower(string userId, CancellationToken cancellationToken = default)
    {
        var entities = await _collection.Find(x => x.FollowerUserId.Equals(ObjectId.Parse(userId))).ToListAsync(cancellationToken);
        return entities.ToModelList();
    }

    public async Task<List<FollowerModel>> GetByFollowed(string userId, CancellationToken cancellationToken = default)
    {
        var entities = await _collection.Find(x => x.FollowedUserId.Equals(ObjectId.Parse(userId))).ToListAsync(cancellationToken);
        return entities.ToModelList();
    }
}
