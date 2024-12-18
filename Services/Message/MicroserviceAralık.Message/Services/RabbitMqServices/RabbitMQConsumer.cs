
using System.Text;
using System.Text.Json;
using MicroserviceAralık.Message.Dtos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MicroserviceAralık.Message.Services.RabbitMqServices;

public class RabbitMQConsumer : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public RabbitMQConsumer(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        channel.QueueDeclare(
            queue: "messages_queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
            );
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var messageJson = Encoding.UTF8.GetString(body);
            var message = JsonSerializer.Deserialize<CreateMessageDto>(messageJson);
            Console.WriteLine("Mesaj consume edildi! " + messageJson);

        };
        channel.BasicConsume(queue: "messages_queue",
            autoAck: true, consumer: consumer);
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }



}
