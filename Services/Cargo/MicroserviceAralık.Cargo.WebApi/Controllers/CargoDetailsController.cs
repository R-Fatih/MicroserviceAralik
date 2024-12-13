using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Cargo.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController(ICargoDetailService _cargoDetailService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCargoDetails()
    {
        var result = await _cargoDetailService.GetAllAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoDetailById(int id)
    {
        var result = await _cargoDetailService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("GetSentCargoDetails")]
    public async Task<IActionResult> GetSentCargoDetails(int customerId)
    {
        var result = await _cargoDetailService.GetSentCargoDetailByCustomerId(customerId);
        return Ok(result);
    }
    [HttpGet("GetReceivedCargoDetails")]
    public async Task<IActionResult> GetReceivedCargoDetails(int customerId)
    {
        var result = await _cargoDetailService.GetReceivedCargoDetailByCustomerId(customerId);
        return Ok(result);
    }


}
