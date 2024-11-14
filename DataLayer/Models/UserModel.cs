using DataLayer.Enums;
using DataLayer.Models.Base;
using MongoDB.Bson;

namespace DataLayer.Models
{
        public class UserModel : BaseModel
        {
                public string Username { get; set; } = null!;

                public Roles Role { get; set; }

        }

        public class UserSimpleModel : BaseViewModel
        {

                public string Username { get; set; } = null!;

                public Roles Role { get; set; }
        }

        public class UserCreateModel : BaseCreateModel
        {
                public string Username { get; set; } = null!;

                public string Password { get; set; } = null!;

                public Roles Role { get; set; }
        }

        public class UserUpdateModel : BaseUpdateModel
        {
                public string Username { get; set; } = null!;

                public Roles Role { get; set; }
        }
}