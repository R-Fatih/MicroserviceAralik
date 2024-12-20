using MicroserviceAralık.Payment.Models;

namespace MicroserviceAralık.Payment.Events;

public class InventoryReserveStatusEvent
{
    public List<CreateOrderDetailCommand> OrderList { get; set; }
}
