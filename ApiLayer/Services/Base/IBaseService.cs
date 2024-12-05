
using DataLayer.Postgre.Entity;
using DataLayer.Models.Base;

namespace ApiLayer.Services.Base;

public interface IBaseService<TModel>
where TModel : BaseViewModel
{
    Task<Result<TModel>> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<Result<List<TModel>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<TModel>> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default);
    Task<Result<TModel>> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default);
    Task<Result<TModel>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
