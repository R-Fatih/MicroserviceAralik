using MicroserviceAralık.Inventory.Models;

namespace MicroserviceAralık.Inventory.Events;

public class PaymentStatusEvent
{
    public List<CreateOrderDetailCommand> OrderList { get; set; }
    public bool PaymentStatus { get; set; }
}
