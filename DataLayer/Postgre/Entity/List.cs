using DataLayer.Enums;
namespace DataLayer.Postgre.Entity;
public class List : BasePostGre
{
    public string Title { get; set; } = null!;

    public Guid UserId { get; set; }

    public Status Status { get; set; }

    public virtual List<ListItem>? ListItems { get; set; }

    public virtual User? User { get; set; }
}