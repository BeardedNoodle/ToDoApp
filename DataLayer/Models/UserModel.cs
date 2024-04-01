using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Models
{
        public class UserModel
        {
                public long Id { get; set; }

                public string Username { get; set; } = null!;

                public Roles Role { get; set; }

                public List<ListModel> ListModels { get; set; } = new List<ListModel>();

                public List<UserSimpleModel> Followers { get; set; } = new List<UserSimpleModel>();

                public List<UserSimpleModel> Following { get; set; } = new List<UserSimpleModel>();
        }

        public class UserSimpleModel
        {
                public long Id { get; set; }

                public string Username { get; set; } = null!;

                public Roles Role { get; set; }
        }

        public class UserCreateModel
        {
                public string Username { get; set; } = null!;

                public string Password { get; set; } = null!;

                public Roles Role { get; set; }
        }
}