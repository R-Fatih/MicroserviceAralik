namespace MicroserviceAralık.RabbitMQ.Abstract;
public interface IRabbitMQPublisher
{
    void Publish<T>(string queueName, T message);
}
