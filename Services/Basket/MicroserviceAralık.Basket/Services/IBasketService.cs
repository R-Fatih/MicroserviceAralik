using MicroserviceAralık.Basket.Dtos;

namespace MicroserviceAralık.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket(string? userId);
    Task SaveBasket(BasketTotalDto dto);
    Task DeleteBasket();
}
