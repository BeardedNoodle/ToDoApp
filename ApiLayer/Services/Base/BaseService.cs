using ApiLayer.Services.Base;
using DataLayer.Models.Base;
using DataLayer.Postgre;
using DataLayer.Postgre.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiLayer.Services;
public abstract class BaseService<TModel, TEntity> : IBaseService<TModel>
where TModel : BaseViewModel
where TEntity : BasePostGre
{
    private readonly AppDbContext _context;

    protected BaseService(AppDbContext context)
    {
        _context = context;
    }

    protected AppDbContext appDbContext => _context;

    abstract protected DbSet<TEntity> GetDbSet();

    abstract public Task<TModel?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    abstract public Task<List<TModel>> GetAllAsync(CancellationToken cancellationToken = default);
    abstract public Task<TModel> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default);
    abstract public Task<TModel> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default);

    abstract public Task<TModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    protected async Task<TEntity> SaveAsync(TEntity entity, CancellationToken cancellationToken = default)
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

    protected async Task<TEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetDbSet().Where(x => x.Id == id && !x.isDeleted).FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            throw new Exception();

        return entity;
    }

    protected async Task<TEntity> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await FindByIdAsync(id, cancellationToken);

        entity.isDeleted = true;
        var result = await SaveAsync(entity, cancellationToken);
        return result;
    }
}
