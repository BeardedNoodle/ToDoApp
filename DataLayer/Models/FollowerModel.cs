using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class FollowerModel
    {
        public string FollowerUserId { get; set; } = null!;

        public string FollowedUserId { get; set; } = null!;
    }

    public class FollowerCreateModel
    {
        public string FollowerUserId { get; set; } = null!;

        public string FollowedUserId { get; set; } = null!;
    }
}