
using DataLayer.Mappers;
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
        return appDbContext.Follower;
    }
    public override async Task<FollowerModel> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not FollowerCreateModel createModel)
            throw new ArgumentException("");

        var entity = createModel.ToEntity();

        var result = await SaveAsync(entity!, cancellationToken);

        return result.ToModel();
    }

    public override async Task<FollowerModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await FindByIdAsync(id, cancellationToken);

        entity.isDeleted = true;
        var result = await SaveAsync(entity, cancellationToken);
        return result.ToModel();
    }

    public override async Task<List<FollowerModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var results = await GetDbSet().Where(x => !x.isDeleted).Select(x => new FollowerModel
        {
            Id = x.Id,
            FollowedUserId = x.FollowedUserId.ToString(),
            FollowerUserId = x.FollowerUserId.ToString()
        }).ToListAsync(cancellationToken);
        return results;
    }

    public override async Task<FollowerModel?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var results = await GetDbSet().Where(x => !x.isDeleted).FirstOrDefaultAsync(cancellationToken);

        if (results == null)
            throw new KeyNotFoundException();

        return results.ToModel();
    }

    public override Task<FollowerModel> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private async Task<Follower> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetDbSet().Where(x => x.Id == id && !x.isDeleted).FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            throw new Exception();

        return entity;
    }

    private async Task<Follower> SaveAsync(Follower entity, CancellationToken cancellationToken = default)
    {
        try
        {
            await GetDbSet().AddAsync(entity, cancellationToken);
            await appDbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR : {ex.Message}");
            throw new Exception();
        }
        return entity;
    }

}
