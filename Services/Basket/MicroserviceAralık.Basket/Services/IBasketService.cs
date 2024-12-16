using MicroserviceAralık.Basket.Dtos;

namespace MicroserviceAralık.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket();
    Task SaveBasket(BasketTotalDto dto);
    Task DeleteBasket();
}
