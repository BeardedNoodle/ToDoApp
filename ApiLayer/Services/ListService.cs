using DataLayer.Mappers;
using DataLayer.Models;
using DataLayer.Mongo.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using ServiceLayer.MongoService;

namespace ApiLayer.Services;

public class ListService
{
    private readonly IMongoCollection<List> _collection;

    public ListService(MongoDbContext db)
    {
        _collection = db.Lists;
    }

    public async Task<ListModel> CreateAsync(ListCreateModel model, CancellationToken cancellationToken = default)
    {
        var entity = model.ToEntity();
        await _collection.InsertOneAsync(entity, null, cancellationToken);
        return entity.ToModel();
    }

    public async Task<List<ListModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entites = await _collection.Find(_ => true).ToListAsync(cancellationToken);
        return entites.ToModelList();
    }

    public async Task<ListModel> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _collection.Find(x => x.Id.Equals(ObjectId.Parse(id))).FirstOrDefaultAsync(cancellationToken);
        return entity.ToModel();
    }
}
