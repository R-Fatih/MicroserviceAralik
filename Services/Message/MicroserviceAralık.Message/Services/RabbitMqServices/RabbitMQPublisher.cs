using System.Text;
using System.Text.Json;
using MicroserviceAralık.Message.Dtos;
using MicroserviceAralık.Message.Services.MessageServices;
using RabbitMQ.Client;

namespace MicroserviceAralık.Message.Services.RabbitMqServices;

public class RabbitMQPublisher
{
    private readonly string _hostname = "localhost";
    private readonly string _queueName = "messages_queue";
    private readonly IMessageService _messageService;

    public RabbitMQPublisher(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public async void Publish<T>(T message) where T : CreateMessageDto
    {
        var factory = new ConnectionFactory
        {
            HostName = _hostname
        };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        channel.QueueDeclare(
            queue: _queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
            );
        var messageBody = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(messageBody);

        channel.BasicPublish(
            exchange: "",
            routingKey: _queueName,
            basicProperties: null,
            body: body);
        await _messageService.CreateMessage(message);
        Console.WriteLine("Mesaj kuyruğa alındı ve dbye yazıldı.");
    }
}
