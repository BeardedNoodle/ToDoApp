using ApiLayer.Services.Base;
using DataLayer.Mappers;
using DataLayer.Models;
using DataLayer.Models.Base;
using DataLayer.Postgre;
using DataLayer.Postgre.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiLayer.Services;

public class ListItemService : BaseService<ListItemModel, ListItem>
{
    public ListItemService(AppDbContext context) : base(context)
    {
    }

    protected override DbSet<ListItem> GetDbSet()
    {
        return appDbContext.ListItems;
    }

    public override async Task<Result<ListItemModel>> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not ListItemCreateModel createModel)
            throw new ArgumentException("");

        var entity = createModel.ToEntity();

        var result = await SaveAsync(entity, cancellationToken);

        return Result<ListItemModel>.Success(result.ToModel());
    }

    public override async Task<Result<ListItemModel>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await DeleteByIdAsync(id, cancellationToken);

        if (result == null)
            return Result<ListItemModel>.Failure(ListItemErrors.NotFound);

        return Result<ListItemModel>.Success(result.ToModel());
    }

    public override async Task<Result<List<ListItemModel>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var results = await GetDbSet().Where(x => !x.isDeleted).Select(x => new ListItemModel
        {
            Id = x.Id,
            Body = x.Body,
            ListId = x.ListId,
            Status = x.Status,
        }).ToListAsync(cancellationToken);
        return Result<List<ListItemModel>>.Success(results);
    }

    public override async Task<Result<ListItemModel>> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var result = await GetDbSet().Where(x => !x.isDeleted).FirstOrDefaultAsync(cancellationToken);

        if (result == null)
            return Result<ListItemModel>.Failure(ListItemErrors.NotFound);

        return Result<ListItemModel>.Success(result.ToModel());

    }

    public override async Task<Result<ListItemModel>> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not ListItemUpdateModel updateModel)
            throw new ArgumentException("");

        var entity = await FindByIdAsync(model.Id, cancellationToken);

        if (entity == null)
            return Result<ListItemModel>.Failure(ListItemErrors.NotFound);

        updateModel.ToEntity(entity);

        var result = await SaveAsync(entity, cancellationToken);

        return Result<ListItemModel>.Success(result.ToModel());
    }

}

public static class ListItemErrors
{
    public static readonly ErrorResult NotFound = ErrorResult.NotFound("List Item Not Found", "Not Found");
}