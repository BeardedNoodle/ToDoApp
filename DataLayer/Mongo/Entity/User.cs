using DataLayer.Enums;

namespace DataLayer.Mongo.Entity;
public class User : BaseMongo
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Roles Role { get; set; }

}
