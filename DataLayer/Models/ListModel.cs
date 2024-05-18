using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Enums;
using MongoDB.Bson;

namespace DataLayer.Models
{
    public class ListModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public ObjectId UserId { get; set; }

        public Status Status { get; set; }

        public UserSimpleModel User { get; set; } = null!;

        public List<ListItemModel> ListItems { get; set; } = new List<ListItemModel>();
    }

    public class ListSimpleModel
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; } = null!;

        public ObjectId UserId { get; set; }

        public Status Status { get; set; }

    }

    public class ListCreateModel
    {
        public string Title { get; set; } = null!;

        public ObjectId UserId { get; set; }

        public Status Status { get; set; }

        public List<ListItemCreateModel>? ListItems { get; set; }
    }

    public class ListUpdateModel
    {
        public string Title { get; set; } = null!;
        public Status Status { get; set; }
    }
}