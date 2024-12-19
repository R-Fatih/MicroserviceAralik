using MicroserviceAralık.Inventory.Dtos.StockDtos;
using MicroserviceAralık.Inventory.Services.StockServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Inventory.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StocksController(IStockService _stockService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _stockService.GetAllStocks());
    }
    [HttpPost]
    public async Task<IActionResult> CreateStock(CreateStockDto dto)
    {
        await _stockService.CreateStock(dto);
        return Ok("Stock created succesfully");
    }
}
