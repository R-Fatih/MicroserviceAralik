using MediatR;
using MicroserviceAralık.Order.Application.Events;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralık.RabbitMQ.Abstract;

namespace MicroserviceAralık.Order.Presentation.Consumer;
public class OrderConsumer : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public OrderConsumer(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = _serviceScopeFactory.CreateScope();
        var rabbitSubscriber = scope.ServiceProvider.GetRequiredService<IRabbitMQSubscriber>();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var rabbitPublisher = scope.ServiceProvider.GetRequiredService<IRabbitMQPublisher>();
        rabbitSubscriber.Subscribe<BasketCreatedEvent>("BasketCreatedQueue", async (message) =>
        {
            await Task.Delay(5000);
            var newOrderDetails = message.BasketItems.Select(x => new CreateOrderDetailCommand
            {
                OrderingId = message.OrderingId,
                ProductAmount = x.Quantity,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.Price,
                TotalPrice = (x.Price * x.Quantity)
            }).ToList();

            await mediator.Send(new CreateOrderDetailArrayCommand(newOrderDetails));

            var orderDetailCreatedEvent = new OrderDetailCreatedEvent
            {
                OrderList = newOrderDetails
            };

            rabbitPublisher.Publish<OrderDetailCreatedEvent>("OrderDetailCreatedQueue", orderDetailCreatedEvent);
        });

        rabbitSubscriber.Subscribe<InventoryReserveStatusEvent>("InventoryReserveStatusQueue", async (message) =>
        {

        })

        await Task.Delay(Timeout.Infinite, stoppingToken);

    }
}
