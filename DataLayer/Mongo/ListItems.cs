using DataLayer.Enums;

namespace DataLayer.Mongo;

public class ListItems {

    public long Id { get; set; }

    public string Body { get; set; } = null!;

    public long ListId {get; set;}

    public Status Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual List List {get; set;} = null!;
}