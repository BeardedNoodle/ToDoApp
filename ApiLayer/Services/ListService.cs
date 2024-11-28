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

    public override async Task<ListModel> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not ListCreateModel createModel)
            throw new ArgumentException("");

        var entity = createModel.ToEntity();

        var result = await SaveAsync(entity, cancellationToken);

        return result.ToModel();
    }

    public override async Task<ListModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await DeleteByIdAsync(id, cancellationToken);

        return result.ToModel();
    }

    public override async Task<List<ListModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var results = await GetDbSet().Where(x => !x.isDeleted).Select(x => new ListModel
        {
            Id = x.Id,
            Title = x.Title,
            Status = x.Status,
            UserId = x.UserId,
        }).ToListAsync(cancellationToken);
        return results;
    }

    public override async Task<ListModel?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
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
            return null;
        return entity.ToModel();
    }

    public override async Task<ListModel> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not ListUpdateModel updateModel)
            throw new ArgumentException("");

        var entity = await FindByIdAsync(model.Id, cancellationToken);

        updateModel.ToEntity(entity);

        var result = await SaveAsync(entity, cancellationToken);

        return result.ToModel();
    }

}
