namespace MicroserviceAralık.Order.Application.Interfaces;
public interface IWriteRepository<TEntity> where TEntity : class
{
    Task CreateArrayAsync(List<TEntity> entities);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
}
