using ApiLayer.Services.Base;
using DataLayer.Mappers;
using DataLayer.Models;
using DataLayer.Models.Base;
using DataLayer.Postgre;
using DataLayer.Postgre.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiLayer.Services;

public class ListService : BaseService<ListModel, List>
{
    public ListService(AppDbContext context) : base(context)
    {
    }

    protected override DbSet<List> GetDbSet()
    {
        return appDbContext.Lists;
    }

    public override async Task<Result<ListModel>> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not ListCreateModel createModel)
            throw new ArgumentException("");

        var entity = createModel.ToEntity();

        var result = await SaveAsync(entity, cancellationToken);

        return Result<ListModel>.Success(result.ToModel());
    }

    public override async Task<Result<ListModel>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await DeleteByIdAsync(id, cancellationToken);

        if (result is null)
            return Result<ListModel>.Failure(ListErrors.NotFound);

        return Result<ListModel>.Success(result.ToModel());
    }

    public override async Task<Result<List<ListModel>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var results = await GetDbSet().Where(x => !x.isDeleted).Select(x => new ListModel
        {
            Id = x.Id,
            Title = x.Title,
            Status = x.Status,
            UserId = x.UserId,
        }).ToListAsync(cancellationToken);
        return Result<List<ListModel>>.Success(results);
    }

    public override async Task<Result<ListModel>> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var entity = await GetDbSet().Where(x => x.Id == Id && !x.isDeleted).Select(x => new List
        {
            Id = x.Id,
            Title = x.Title,
            Status = x.Status,
            UserId = x.UserId,
            ListItems = x.ListItems
        }).FirstOrDefaultAsync(cancellationToken);
        if (entity == null)
            return Result<ListModel>.Failure(ListErrors.NotFound);
        return Result<ListModel>.Success(entity.ToModel());
    }

    public override async Task<Result<ListModel>> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not ListUpdateModel updateModel)
            throw new ArgumentException("");

        var entity = await FindByIdAsync(model.Id, cancellationToken);

        if (entity == null)
            return Result<ListModel>.Failure(ListErrors.NotFound);
        updateModel.ToEntity(entity);

        var result = await SaveAsync(entity, cancellationToken);

        return Result<ListModel>.Success(result.ToModel());
    }
}

public static class ListErrors
{
    public static readonly ErrorResult NotFound = ErrorResult.NotFound("List Not Found", "Not Found");
}
