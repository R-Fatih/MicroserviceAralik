using MediatR;
using MicroserviceAralık.Order.Application.Events;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.RabbitMQ.Abstract;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
public class CreateOrderingCommandHandler(IOrderingRepository _orderingRepository, IRabbitMQPublisher _rabbitMQPublisher) : IRequestHandler<CreateOrderingCommand, int>
{
    public async Task<int> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {

        var value = await _orderingRepository.CreateOrdering(request);
        var orderCreatedEvent = new OrderCreatedEvent
        {
            Id = value,
            OrderDate = request.OrderDate,
            TotalPrice = request.TotalPrice,
            UserId = request.UserId
        };
        _rabbitMQPublisher.Publish("OrderCreatedQueue", orderCreatedEvent);
        return value;
    }
}
