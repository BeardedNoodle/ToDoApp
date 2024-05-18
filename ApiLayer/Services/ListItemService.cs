using DataLayer.Mappers;
using DataLayer.Models;
using DataLayer.Mongo.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using ServiceLayer.MongoService;

namespace ApiLayer.Services;

public class ListItemService
{
    private readonly IMongoCollection<ListItem> _collection;

    public ListItemService(MongoDbContext db)
    {
        _collection = db.ListItems;
    }

    public async Task<List<ListItemModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entites = await _collection.Find(_ => true).ToListAsync(cancellationToken);
        return entites.ToModelList();
    }

    public async Task<ListItemModel> GetByIdAsync(string id)
    {
        var entity = await _collection.Find(x => x.Id.Equals(ObjectId.Parse(id))).FirstOrDefaultAsync();
        return entity.ToModel();
    }

    public async Task<ListItemModel> CreateAsync(ListItemCreateModel model)
    {
        var entity = model.ToEntity();
        await _collection.InsertOneAsync(entity);
        return entity.ToModel();
    }

    public async Task<List<ListItemModel>> CreateAsync(List<ListItemCreateModel> model)
    {
        var entities = model.ToEntityList();

        if (entities == null || entities.Count == 0)
        {
            throw new NotImplementedException();
        }
        await _collection.InsertManyAsync(entities);
        return entities.ToModelList();
    }

}
