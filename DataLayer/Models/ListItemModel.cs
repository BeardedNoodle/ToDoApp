using DataLayer.Enums;
using DataLayer.Models.Base;

namespace DataLayer.Models
{
    public class ListItemModel : BaseModel
    {

        public string Body { get; set; } = null!;

        public Guid ListId { get; set; }

        public Status Status { get; set; }

        public virtual ListSimpleModel List { get; set; } = null!;
    }

    public class ListItemSimpleModel : BaseViewModel
    {

        public string Body { get; set; } = null!;

        public Guid ListId { get; set; }

        public Status Status { get; set; }
    }

    public class ListItemCreateModel : BaseCreateModel
    {
        public string Body { get; set; } = null!;

        public Guid ListId { get; set; }

        public Status Status { get; set; }

    }

    public class ListItemUpdateModel : BaseUpdateModel
    {

        public string Body { get; set; } = null!;

        public Status Status { get; set; }

    }
}