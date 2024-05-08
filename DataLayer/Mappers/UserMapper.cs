
using DataLayer.Models;
using DataLayer.Mongo.Entity;

namespace DataLayer.Mappers
{
    public static class UserMapper
    {
        public static UserModel ToModel(this User entity)
        {
            return new UserModel
            {
                Id = entity.Id.ToString(),
                Username = entity.Username,
                Role = entity.Role
            };
        }

        public static List<UserModel> ToModelList(this List<User> entites)
        {
            return entites.Select(ToModel).ToList();
        }

        public static UserSimpleModel ToSimpleModel(this User entity)
        {
            return new UserSimpleModel
            {
                Id = entity.Id.ToString(),
                Username = entity.Username,
                Role = entity.Role
            };
        }

        public static List<UserSimpleModel> ToSimpleModelList(this List<User> entites)
        {
            return entites.Select(ToSimpleModel).ToList();
        }

        public static User ToEntity(this UserCreateModel model)
        {
            return new User
            {
                Username = model.Username,
                Password = model.Password,
                Role = Enums.Roles.User,
                CreatedAt = DateTime.Now,
            };
        }
    }
}