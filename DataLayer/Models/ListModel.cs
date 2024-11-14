
using DataLayer.Enums;
using DataLayer.Models.Base;

namespace DataLayer.Models
{
    public class ListModel : BaseModel
    {
        public string Title { get; set; } = null!;

        public Guid UserId { get; set; }

        public Status Status { get; set; }

        public UserSimpleModel User { get; set; } = null!;

        public List<ListItemModel> ListItems { get; set; } = new List<ListItemModel>();
    }

    public class ListSimpleModel : BaseViewModel
    {
        public string Title { get; set; } = null!;

        public Guid UserId { get; set; }

        public Status Status { get; set; }

    }

    public class ListCreateModel : BaseCreateModel
    {
        public string Title { get; set; } = null!;

        public Guid UserId { get; set; }

        public Status Status { get; set; }

        public List<ListItemCreateModel>? ListItems { get; set; }
    }

    public class ListUpdateModel : BaseUpdateModel
    {
        public string Title { get; set; } = null!;
        public Status Status { get; set; }
    }
}