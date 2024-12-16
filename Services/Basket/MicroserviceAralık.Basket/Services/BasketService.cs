using System.Security.Claims;
using System.Text.Json;
using MicroserviceAralık.Basket.Dtos;
using MicroserviceAralık.Basket.Settings;

namespace MicroserviceAralık.Basket.Services;

public class BasketService : IBasketService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly RedisService _redisService;

    public BasketService(IHttpContextAccessor httpContextAccessor, RedisService redisService)
    {
        _httpContextAccessor = httpContextAccessor;
        _redisService = redisService;
    }

    public async Task DeleteBasket()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        await _redisService.GetDatabase().KeyDeleteAsync(userId);

    }

    public async Task<BasketTotalDto> GetBasket()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var getBasket = await _redisService.GetDatabase().StringGetAsync(userId);
        return JsonSerializer.Deserialize<BasketTotalDto>(getBasket);
    }

    public async Task SaveBasket(BasketTotalDto dto)
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        await _redisService.GetDatabase().StringSetAsync(userId, JsonSerializer.Serialize(dto));
    }
}
