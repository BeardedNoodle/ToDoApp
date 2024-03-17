using DataLayer.Enums;

namespace DataLayer.Mongo.Entity;

public class ListItem : BaseMongo
{

    public string Body { get; set; } = null!;

    public long ListId { get; set; }

    public Status Status { get; set; }

    public virtual List List { get; set; } = null!;
}