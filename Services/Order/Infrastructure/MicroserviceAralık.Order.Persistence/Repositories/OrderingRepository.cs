using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;
using MicroserviceAralık.Order.Persistence.Context;

namespace MicroserviceAralık.Order.Persistence.Repositories;
public class OrderingRepository(AppDbContext _context) : IOrderingRepository
{
    public async Task<int> CreateOrdering(CreateOrderingCommand command)
    {
        var entity = new Ordering
        {
            OrderDate = DateTime.Now,
            TotalPrice = command.TotalPrice,
            UserId = command.UserId,
        };
        var added = await _context.Orderings.AddAsync(entity);
        await _context.SaveChangesAsync();
        return added.Entity.Id;
    }
}
