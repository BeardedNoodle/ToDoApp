namespace DataLayer.Mongo.Entity;

public class Follower : BaseMongo
{

    public long FollowerUserId { get; set; }

    public long FollowedUserId { get; set; }

}