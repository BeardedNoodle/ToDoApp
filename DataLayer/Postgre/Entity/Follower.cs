using MongoDB.Bson;

namespace DataLayer.Postgre.Entity;

public class Follower : BasePostGre
{

    public Guid FollowerUserId { get; set; }

    public Guid FollowedUserId { get; set; }

    public virtual User? FollowerUser { get; set; }

    public virtual User? FollowedUser { get; set; }

}