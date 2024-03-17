using MongoDB.Bson.Serialization.Attributes;

namespace DataLayer.Mongo.Entity;
public class BaseMongo
{
    [BsonId]
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }
}
