
using DataLayer.Models;
using DataLayer.Mongo.Entity;

namespace DataLayer.Mappers
{
    public static class UserMapper
    {
        public static UserModel ToModel(this User user)
        {
                return new UserModel{
                    Username = user.Username,
                    Role = user.Role
                };
        }
    }
}