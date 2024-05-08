using DataLayer.Enums;
using MongoDB.Bson;

namespace DataLayer.Models
{
    public class ListItemModel
    {
        public ObjectId Id { get; set; }

        public string Body { get; set; } = null!;

        public long ListId { get; set; }

        public Status Status { get; set; }

        public virtual ListSimpleModel List { get; set; } = null!;
    }

    public class ListItemCreateModel
    {
        public string Body { get; set; } = null!;

        public long ListId { get; set; }

        public Status Status { get; set; }

    }

    public class ListItemUpdateModel
    {
        public string Body { get; set; } = null!;

        public Status Status { get; set; }

    }
}