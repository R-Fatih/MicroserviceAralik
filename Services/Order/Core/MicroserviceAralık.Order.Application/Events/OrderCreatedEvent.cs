namespace MicroserviceAralık.Order.Application.Events;
public class OrderCreatedEvent
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
