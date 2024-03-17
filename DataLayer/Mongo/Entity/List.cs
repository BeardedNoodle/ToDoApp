using DataLayer.Enums;

namespace DataLayer.Mongo.Entity;
public class List : BaseMongo
{
    public string Title { get; set; } = null!;

    public long UserId { get; set; }

    public Status Status { get; set; }

    public List<ListItem>? ListItems { get; set; }
}