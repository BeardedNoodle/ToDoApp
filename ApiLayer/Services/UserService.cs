using DataLayer.Models;
using MongoDB.Driver;
using DataLayer.Mappers;
using DataLayer.Postgre.Entity;
using DataLayer.Postgre;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models.Base;
using Microsoft.AspNetCore.Http.HttpResults;
using ApiLayer.Services.Base;

namespace ApiLayer.Services;

public class UserService : BaseService<UserModel, User>
{

    public UserService(AppDbContext context) : base(context)
    {
    }

    protected override DbSet<User> GetDbSet() => appDbContext.Users;

    public override async Task<Result<UserModel>> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var user = await GetDbSet().Where(x => x.Id == Id && !x.isDeleted).FirstOrDefaultAsync(cancellationToken);
        if (user == null)
            return Result<UserModel>.Failure(UserErrors.NotFound);
        return Result<UserModel>.Success(user.ToModel());
    }

    public async Task<Result<UserSimpleModel>> GetSimpleModelByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await GetDbSet().Where(x => x.Id == id && !x.isDeleted).FirstOrDefaultAsync(cancellationToken);
        if (user == null)
            return Result<UserSimpleModel>.Failure(UserErrors.NotFound);
        return Result<UserSimpleModel>.Success(user.ToSimpleModel());
    }

    public override async Task<Result<List<UserModel>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var results = await GetDbSet().Where(x => !x.isDeleted).Select(x => new UserModel
        {
            Id = x.Id,
            Username = x.Username
        }).ToListAsync(cancellationToken);
        return Result<List<UserModel>>.Success(results);
    }

    public override async Task<Result<UserModel>> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not UserCreateModel createModel)
            throw new ArgumentException("UserCreateModel");

        var entity = createModel.ToEntity();

        var result = await SaveAsync(entity, cancellationToken);

        return Result<UserModel>.Success(result.ToModel());
    }
    public override async Task<Result<UserModel>> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not UserUpdateModel updateModel)
            throw new ArgumentException("UserUpdateModel");

        var entity = await FindByIdAsync(model.Id, cancellationToken);
        if (entity is null)
            return Result<UserModel>.Failure(UserErrors.NotFound);
        updateModel.ToEntity(entity);

        var result = await SaveAsync(entity, cancellationToken);

        return Result<UserModel>.Success(result.ToModel());
    }

    public override async Task<Result<UserModel>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await DeleteByIdAsync(id, cancellationToken);
        if (result is null)
            return Result<UserModel>.Failure(UserErrors.NotFound);
        return Result<UserModel>.Success(result.ToModel());
    }
}

public static class UserErrors
{
    public static readonly ErrorResult NotFound = ErrorResult.NotFound("User Not Found", "Not Found");

}
