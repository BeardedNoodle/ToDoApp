using MongoDB.Bson;

namespace DataLayer.Mongo.Entity;

public class Follower : BaseMongo
{

    public ObjectId FollowerUserId { get; set; }

    public ObjectId FollowedUserId { get; set; }

}