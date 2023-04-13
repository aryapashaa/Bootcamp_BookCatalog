namespace BookCatalog_API.Repositories.Interface;

public interface IRepository<Key, Entity> where Entity : class
{
    Task<IEnumerable<Entity>> GetAll();
    Task<Entity?> GetById(Key key);
    Task<int> Insert(Entity entity);
    Task<int> Update(Entity entity);
    Task<int> Delete(Key key);
}