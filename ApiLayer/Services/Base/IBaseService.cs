
using DataLayer.Postgre.Entity;
using DataLayer.Models.Base;

namespace ApiLayer.Services.Base;

public interface IBaseService<TModel>
where TModel : BaseViewModel
{
    Task<TModel?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<List<TModel>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TModel> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default);
    Task<TModel> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default);
    Task<TModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
