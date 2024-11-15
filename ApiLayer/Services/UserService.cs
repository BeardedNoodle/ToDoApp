using DataLayer.Models;
using MongoDB.Driver;
using DataLayer.Mappers;
using DataLayer.Postgre.Entity;
using DataLayer.Postgre;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models.Base;

namespace ApiLayer.Services;

public class UserService : BaseService<UserModel, User>
{

    public UserService(AppDbContext context) : base(context)
    {
    }

    protected override DbSet<User> GetDbSet() => appDbContext.Users;

    public override async Task<UserModel?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var user = await GetDbSet().Where(x => x.Id == Id && !x.isDeleted).FirstOrDefaultAsync(cancellationToken);
        if (user == null)
            return null;
        return user.ToModel();
    }

    public async Task<UserSimpleModel?> GetSimpleModelByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await GetDbSet().Where(x => x.Id == id && !x.isDeleted).FirstOrDefaultAsync(cancellationToken);
        if (user == null)
            return null;
        return user.ToSimpleModel();
    }

    public override async Task<List<UserModel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var results = await GetDbSet().Where(x => !x.isDeleted && x.Role != DataLayer.Enums.Roles.Admin).Select(x => new UserModel
        {
            Id = x.Id,
            Username = x.Username
        }).ToListAsync(cancellationToken);
        return results;
    }

    public override async Task<UserModel> CreateAsync(BaseCreateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not UserCreateModel createModel)
            throw new ArgumentException("");

        var entity = createModel.ToEntity();

        var result = await SaveUserAsync(entity, cancellationToken);

        return result.ToModel();
    }
    public override async Task<UserModel> UpdateAsync(BaseUpdateModel model, CancellationToken cancellationToken = default)
    {
        if (model is not UserUpdateModel updateModel)
            throw new ArgumentException("");

        var entity = await GetUserAsync(model.Id, cancellationToken);

        updateModel.ToEntity(entity);

        var result = await SaveUserAsync(entity, cancellationToken);

        return result.ToModel();
    }

    public override async Task<UserModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetUserAsync(id, cancellationToken);

        entity.isDeleted = true;
        var result = await SaveUserAsync(entity, cancellationToken);
        return result.ToModel();
    }

    private async Task<User> GetUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetDbSet().Where(x => x.Id == id && !x.isDeleted).FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
            throw new Exception("User Not Found");

        return entity;
    }

    private async Task<User> SaveUserAsync(User entity, CancellationToken cancellationToken = default)
    {
        try
        {
            await GetDbSet().AddAsync(entity, cancellationToken);
            await appDbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR : {ex.Message}");
            throw new Exception(ex.ToString());
        }
        return entity;
    }

}
