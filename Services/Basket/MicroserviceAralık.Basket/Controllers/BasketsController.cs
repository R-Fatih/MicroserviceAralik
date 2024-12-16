using MicroserviceAralık.Basket.Dtos;
using MicroserviceAralık.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Basket.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BasketsController(IBasketService _basketService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBasket()
    {
        var basket = await _basketService.GetBasket();
        return Ok(basket);
    }
    [HttpPost]
    public async Task<IActionResult> SaveBasket(BasketTotalDto dto)
    {
        await _basketService.SaveBasket(dto);
        return Ok("Basket saved successfully!");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        await _basketService.DeleteBasket();
        return Ok("Basket deleted successfully!");
    }
}
