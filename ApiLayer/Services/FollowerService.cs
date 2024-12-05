
using ApiLayer.Services.Base;
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
    public override async Task<Result<FollowerModel>> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not FollowerCreateModel createModel)
            throw new ArgumentException("");

        var entity = createModel.ToEntity();

        var result = await SaveAsync(entity!, cancellationToken);

        return Result<FollowerModel>.Success(result.ToModel());
    }

    public override async Task<Result<FollowerModel>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await DeleteByIdAsync(id, cancellationToken);

        if (result is null)
            return Result<FollowerModel>.Failure(FollowerErrors.NotFound);

        return Result<FollowerModel>.Success(result.ToModel());
    }

    public override async Task<Result<List<FollowerModel>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var results = await GetDbSet().Where(x => !x.isDeleted).Select(x => new FollowerModel
        {
            Id = x.Id,
            FollowedUserId = x.FollowedUserId.ToString(),
            FollowerUserId = x.FollowerUserId.ToString()
        }).ToListAsync(cancellationToken);

        return Result<List<FollowerModel>>.Success(results);
    }

    public override async Task<Result<FollowerModel>> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var result = await GetDbSet().Where(x => !x.isDeleted).FirstOrDefaultAsync(cancellationToken);

        if (result is null)
            return Result<FollowerModel>.Failure(FollowerErrors.NotFound);

        return Result<FollowerModel>.Success(result.ToModel());
    }

    public override Task<Result<FollowerModel>> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Result<FollowerModel>.Failure(FollowerErrors.Forbidden));
    }
}

public static class FollowerErrors
{
    public static readonly ErrorResult NotFound = ErrorResult.NotFound("Follower Not Found", "Not Found");
    public static readonly ErrorResult Forbidden = ErrorResult.Forbidden("Forbidden", "Forbidden");
}
