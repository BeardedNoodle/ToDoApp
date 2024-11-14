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
        throw new NotImplementedException();
    }

    public override Task<ListItemModel> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<ListItemModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<List<ListItemModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<ListItemModel?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<ListItemModel> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}
