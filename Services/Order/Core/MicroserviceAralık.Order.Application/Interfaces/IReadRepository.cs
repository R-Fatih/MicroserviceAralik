namespace MicroserviceAralık.Order.Application.Interfaces;
public interface IReadRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);

}
