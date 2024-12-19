using MicroserviceAralık.Basket.Dtos;

namespace MicroserviceAralık.Basket.Events;

public class BasketCreatedEvent
{
    public List<BasketItemDto> BasketItems { get; set; }
}
