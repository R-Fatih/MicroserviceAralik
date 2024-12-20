using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;

namespace MicroserviceAralık.Order.Application.Interfaces;
public interface IOrderDetailRepository
{
    Task UpdateOrderDetail(UpdateOrderDetailCommand command);
}
