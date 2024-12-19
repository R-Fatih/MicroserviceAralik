using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;

namespace MicroserviceAralık.Order.Application.Interfaces;
public interface IOrderingRepository
{
    Task<int> CreateOrdering(CreateOrderingCommand command);
}
