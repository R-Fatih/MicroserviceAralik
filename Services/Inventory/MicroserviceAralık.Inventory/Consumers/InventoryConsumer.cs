﻿
using MicroserviceAralık.Inventory.Events;
using MicroserviceAralık.Inventory.Services.StockServices;
using MicroserviceAralık.RabbitMQ.Abstract;

namespace MicroserviceAralık.Inventory.Consumers;

public class InventoryConsumer : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public InventoryConsumer(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        var scope = _serviceScopeFactory.CreateScope();
        var rabbitSubscriber = scope.ServiceProvider.GetRequiredService<IRabbitMQSubscriber>();
        var rabbitPublisher = scope.ServiceProvider.GetRequiredService<IRabbitMQPublisher>();
        var stockService = scope.ServiceProvider.GetRequiredService<IStockService>();
        rabbitSubscriber.Subscribe<OrderDetailCreatedEvent>("OrderDetailCreatedQueue", async (message) =>
        {
            var list = new InventoryReserveStatusEvent()
            {
                OrderList = new List<Models.CreateOrderDetailCommand>()
            };
            foreach (var item in message.OrderList)
            {
                var result = await stockService.ReserveInventory(item.ProductId, item.ProductAmount);

                item.StockStatus = result;
                list.OrderList.Add(item);


            }
            rabbitPublisher.Publish<InventoryReserveStatusEvent>("InventoryReserveStatusQueue", list);
        });
        rabbitSubscriber.Subscribe<PaymentStatusEvent>("PaymentStatusQueue", async (message) =>
        {
            if (!message.PaymentStatus)
            {
                foreach (var item in message.OrderList)
                {
                    await stockService.RollbackInventory(item.ProductId, item.ProductAmount);
                }
                rabbitPublisher.Publish("PaymentFailed", "");
            }
            else
                rabbitPublisher.Publish("PaymentSucceded", "");
        });
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

}
