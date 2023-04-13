using Client.ViewModels;

namespace Client.Repositories.Interface;

public interface IRepository<Entity, Key>
    where Entity : class
{
    Task<ResponseListVM<Entity>> Get();
    Task<ResponseVM<Entity>> Get(Key id);
    Task<ResponseStatusVM> Post(Entity entity);
    Task<ResponseStatusVM> Put(Entity entity, Key id);
    Task<ResponseStatusVM> Delete(Key id);

}
