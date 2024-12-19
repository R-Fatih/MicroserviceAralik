using MicroserviceAralık.Inventory.Dtos.WarehouseDtos;
using MicroserviceAralık.Inventory.Services.WarehouseServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Inventory.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WarehousesController(IWarehouseService _warehouseService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _warehouseService.GetAllWarehouses());
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateWarehouseDto dto)
    {
        await _warehouseService.CreateWarehouse(dto);
        return Ok("Created!");
    }
}
