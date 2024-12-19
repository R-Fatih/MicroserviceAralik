using MicroserviceAralık.Order.Application.Models;

namespace MicroserviceAralık.Order.Application.Events;
public class BasketCreatedEvent
{
    public List<BasketItemDto> BasketItems { get; set; }
    public int OrderingId { get; set; }
}
