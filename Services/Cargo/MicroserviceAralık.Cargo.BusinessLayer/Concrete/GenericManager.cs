using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;

namespace MicroserviceAralık.Cargo.BusinessLayer.Concrete;
public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class
{
    protected readonly IGenericDal<TEntity> _genericDal;

    public GenericManager(IGenericDal<TEntity> genericDal)
    {
        _genericDal = genericDal;
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _genericDal.CreateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _genericDal.DeleteAsync(id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _genericDal.GetAllAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _genericDal.GetByIdAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await _genericDal.UpdateAsync(entity);
    }
}
