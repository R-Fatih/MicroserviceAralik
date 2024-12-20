using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Order.Persistence.Repositories;
public class OrderDetailRepository(AppDbContext _context) : IOrderDetailRepository
{
    public async Task UpdateOrderDetail(UpdateOrderDetailCommand command)
    {
        var value = await _context.OrderDetails.FirstOrDefaultAsync(x => x.ProductId == command.ProductId && x.OrderingId == command.OrderingId);
        value.StockStatus = command.StockStatus;
        await _context.SaveChangesAsync();
    }
}
