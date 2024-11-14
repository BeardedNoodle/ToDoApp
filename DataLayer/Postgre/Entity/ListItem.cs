using DataLayer.Enums;

namespace DataLayer.Postgre.Entity;

public class ListItem : BasePostGre
{

    public string Body { get; set; } = null!;

    public Guid ListId { get; set; }

    public Status Status { get; set; }

    public virtual List? List { get; set; }
}