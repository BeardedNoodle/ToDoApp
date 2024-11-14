using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models.Base;

namespace DataLayer.Models
{
    public class FollowerModel : BaseModel
    {
        public string FollowerUserId { get; set; } = null!;

        public string FollowedUserId { get; set; } = null!;
    }

    public class FollowerCreateModel : BaseCreateModel
    {
        public string FollowerUserId { get; set; } = null!;

        public string FollowedUserId { get; set; } = null!;
    }
}