using MicroserviceAralık.Inventory.Models;

namespace MicroserviceAralık.Inventory.Events;

public class InventoryReserveStatusEvent
{
    public List<CreateOrderDetailCommand> OrderList { get; set; }
}
