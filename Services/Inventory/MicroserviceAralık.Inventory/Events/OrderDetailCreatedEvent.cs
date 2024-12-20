using MicroserviceAralık.Inventory.Models;

namespace MicroserviceAralık.Inventory.Events;

public class OrderDetailCreatedEvent
{
    public List<CreateOrderDetailCommand> OrderList { get; set; }
}
