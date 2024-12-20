
using MicroserviceAralık.Payment.Events;
using MicroserviceAralık.RabbitMQ.Abstract;

namespace MicroserviceAralık.Payment.Consumer;

public class PaymentConsumer : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public PaymentConsumer(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var paymentStatus = false;
        var scope = _serviceScopeFactory.CreateScope();
        var rabbitSubscriber = scope.ServiceProvider.GetRequiredService<IRabbitMQSubscriber>();
        var rabbitPublisher = scope.ServiceProvider.GetRequiredService<IRabbitMQPublisher>();
        rabbitSubscriber.Subscribe<InventoryReserveStatusEvent>("InventoryReserveStatusQueue", async (message) =>
                {
                    var paymentEvent = new PaymentStatusEvent
                    {
                        OrderList = message.OrderList,
                        PaymentStatus = paymentStatus
                    };
                    rabbitPublisher.Publish("PaymentStatusQueue", paymentEvent);
                });
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}
