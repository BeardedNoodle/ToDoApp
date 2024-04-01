using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class FollowerModel
    {
        public long FollowerUserId { get; set; }

        public long FollowedUserId { get; set; }
    }

    public class FollowerCreateModel
    {
        public long FollowerUserId { get; set; }

        public long FollowedUserId { get; set; }
    }
}