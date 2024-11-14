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
        throw new NotImplementedException();
    }

    public override Task<ListModel> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<ListModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<List<ListModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<ListModel?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<ListModel> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

}
