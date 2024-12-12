using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Cargo.DataAccessLayer.Repositories;
public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(TEntity entity)
    {

        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {

        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
