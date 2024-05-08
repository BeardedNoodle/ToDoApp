using DataLayer.Enums;
using MongoDB.Bson;

namespace DataLayer.Models
{
        public class UserModel
        {
                public string Id { get; set; } = null!;

                public string Username { get; set; } = null!;

                public Roles Role { get; set; }

                public List<ListModel> ListModels { get; set; } = new List<ListModel>();

                public List<UserSimpleModel> Followers { get; set; } = new List<UserSimpleModel>();

                public List<UserSimpleModel> Following { get; set; } = new List<UserSimpleModel>();
        }

        public class UserSimpleModel
        {
                public string Id { get; set; } = null!;

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