using System.Text;
using System.Text.Json;
using MicroserviceAralık.RabbitMQ.Abstract;
using RabbitMQ.Client;

namespace MicroserviceAralık.RabbitMQ.Concrete;
public class RabbitMQPublisher : IRabbitMQPublisher
{
    private readonly ConnectionFactory _connectionFactory;
    public RabbitMQPublisher(string hostname, string username, string password)
    {
        _connectionFactory = new ConnectionFactory
        {
            HostName = hostname,
            UserName = username,
            Password = password
        };
    }
    public void Publish<T>(string queueName, T message)
    {

        var connection = _connectionFactory.CreateConnection();
        var channel = connection.CreateModel();
        channel.QueueDeclare(
            queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        var messageBody = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(messageBody);
        channel.BasicPublish(
            exchange: "",
            routingKey: queueName,
            basicProperties: null,
            body: body);
    }
}
