using MicroserviceAralık.Basket.Events;
using MicroserviceAralık.Basket.Services;
using MicroserviceAralık.RabbitMQ.Abstract;

namespace MicroserviceAralık.Basket.Consumer;

public class BasketConsumer : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BasketConsumer(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = _serviceScopeFactory.CreateScope();
        var rabbitMqSubscriber = scope.ServiceProvider.GetRequiredService<IRabbitMQSubscriber>();
        var rabbitMqPublisher = scope.ServiceProvider.GetRequiredService<IRabbitMQPublisher>();
        var basketService = scope.ServiceProvider.GetRequiredService<IBasketService>();
        rabbitMqSubscriber.Subscribe<OrderCreatedEvent>("OrderCreatedQueue", async (message) =>
        {

            var values = await basketService.GetBasket();
            var basketCreatedEvent = new BasketCreatedEvent
            {
                BasketItems = values.BasketItems
            };
            rabbitMqPublisher.Publish<BasketCreatedEvent>("BasketCreatedQueue", basketCreatedEvent);
        });
    }
}
