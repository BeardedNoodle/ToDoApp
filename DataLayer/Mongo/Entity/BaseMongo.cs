using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataLayer.Mongo.Entity;
public class BaseMongo
{
    [BsonId]
    public ObjectId Id { get; set; }

    public DateTime CreatedAt { get; set; }
}
