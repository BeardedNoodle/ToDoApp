using DataLayer.Enums;
using MongoDB.Bson;

namespace DataLayer.Mongo.Entity;
public class List : BaseMongo
{
    public string Title { get; set; } = null!;

    public ObjectId UserId { get; set; }

    public Status Status { get; set; }

    public List<ListItem>? ListItems { get; set; }
}