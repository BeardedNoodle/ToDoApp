namespace DataLayer.Mongo;

public class Followers {
    public long Id {get;set;}

    public long followerUserId {get; set;}

    public long followedUserId {get; set;}

    public DateTime CreatedAt { get; set;}
}