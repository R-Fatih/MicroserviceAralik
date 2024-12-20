using MicroserviceAralık.Payment.Models;

namespace MicroserviceAralık.Payment.Events;

public class PaymentStatusEvent
{
    public List<CreateOrderDetailCommand> OrderList { get; set; }
    public bool PaymentStatus { get; set; }
}
