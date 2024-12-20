using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;

namespace MicroserviceAralık.Order.Application.Events;
public class InventoryReserveStatusEvent
{
    public List<CreateOrderDetailCommand> OrderList { get; set; }
}
