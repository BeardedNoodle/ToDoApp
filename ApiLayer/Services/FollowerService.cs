
using DataLayer.Models;
using DataLayer.Models.Base;
using DataLayer.Postgre;
using DataLayer.Postgre.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiLayer.Services;

public class FollowerService : BaseService<FollowerModel, Follower>
{
    public FollowerService(AppDbContext context) : base(context)
    {
    }

    protected override DbSet<Follower> GetDbSet()
    {
        throw new NotImplementedException();
    }
    public override Task<FollowerModel> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<FollowerModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<List<FollowerModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<FollowerModel?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<FollowerModel> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}
