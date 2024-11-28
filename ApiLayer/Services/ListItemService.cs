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

    public override async Task<ListItemModel> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not ListItemCreateModel createModel)
            throw new ArgumentException("");

        var entity = createModel.ToEntity();

        var result = await SaveAsync(entity, cancellationToken);

        return result.ToModel();
    }

    public override async Task<ListItemModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await DeleteByIdAsync(id, cancellationToken);

        return result.ToModel();
    }

    public override async Task<List<ListItemModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var results = await GetDbSet().Where(x => !x.isDeleted).Select(x => new ListItemModel
        {
            Id = x.Id,
            Body = x.Body,
            ListId = x.ListId,
            Status = x.Status,
        }).ToListAsync(cancellationToken);
        return results;
    }

    public override async Task<ListItemModel?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var results = await GetDbSet().Where(x => !x.isDeleted).FirstOrDefaultAsync(cancellationToken);

        if (results == null)
            throw new KeyNotFoundException();

        return results.ToModel();

    }

    public override async Task<ListItemModel> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not ListItemUpdateModel updateModel)
            throw new ArgumentException("");

        var entity = await FindByIdAsync(model.Id, cancellationToken);

        updateModel.ToEntity(entity);

        var result = await SaveAsync(entity, cancellationToken);

        return result.ToModel();
    }

}
