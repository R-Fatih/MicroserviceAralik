using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Persistence.Context;

namespace MicroserviceAralık.Order.Persistence.Repositories;
public class WriteRepository<TEntity>(AppDbContext _context) : IWriteRepository<TEntity> where TEntity : class
{
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

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
