using DataLayer.Models;
using DataLayer.Postgre.Entity;

namespace DataLayer.Mappers;
public static class FollowerMapper
{
    public static FollowerModel ToModel(this Follower entity)
    {
        return new FollowerModel()
        {

            FollowedUserId = entity.FollowedUserId.ToString(),
            FollowerUserId = entity.FollowerUserId.ToString(),
        };
    }

    public static List<FollowerModel> ToModelList(this List<Follower> entites)
    {
        return entites.Select(ToModel).ToList();
    }

    public static Follower ToEntity(this FollowerCreateModel model)
    {
        return new Follower()
        {
            FollowedUserId = Guid.Parse(model.FollowedUserId),
            FollowerUserId = Guid.Parse(model.FollowerUserId),
        };
    }
}