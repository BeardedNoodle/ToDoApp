using DataLayer.Enums;

namespace DataLayer.Postgre.Entity;
public class User : BasePostGre
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Roles Role { get; set; }

}
