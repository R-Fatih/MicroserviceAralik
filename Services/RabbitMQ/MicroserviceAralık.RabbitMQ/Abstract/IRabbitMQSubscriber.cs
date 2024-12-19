namespace MicroserviceAralık.RabbitMQ.Abstract;
public interface IRabbitMQSubscriber
{
    public void Subscribe<T>(string queueName, Func<T, Task> messageHandler);
}
