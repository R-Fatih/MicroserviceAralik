using System.Text;
using System.Text.Json;
using MicroserviceAralık.RabbitMQ.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MicroserviceAralık.RabbitMQ.Concrete;
public class RabbitMQSubscriber : IRabbitMQSubscriber
{
    private readonly ConnectionFactory _connectionFactory;
    public RabbitMQSubscriber(string hostname, string username, string password)
    {
        _connectionFactory = new ConnectionFactory
        {
            HostName = hostname,
            UserName = username,
            Password = password,
            DispatchConsumersAsync = true
        };
    }
    public void Subscribe<T>(string queueName, Func<T, Task> messageHandler)
    {

        var connection =
            _connectionFactory.CreateConnection();
        var channel = connection.CreateModel();
        channel.QueueDeclare(
            queue: queueName,
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
            var message = JsonSerializer.Deserialize<T>(messageJson);

            if (message != null)
            {
                await messageHandler(message);
            }
        };
        channel.BasicConsume(
            queue: queueName,
            autoAck: false,
            consumer: consumer
            );
    }
}
