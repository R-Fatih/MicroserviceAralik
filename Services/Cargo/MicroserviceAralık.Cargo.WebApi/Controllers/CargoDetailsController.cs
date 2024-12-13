using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using MicroserviceAralık.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;
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
    [HttpPost]
    public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
    {
        var newCargoDetail = new CargoDetail
        {
            Barcode = createCargoDetailDto.Barcode,
            CompanyId = createCargoDetailDto.CompanyId,
            ReceiverCustomerId = createCargoDetailDto.ReceiverCustomerId,
            SenderCustomerId = createCargoDetailDto.SenderCustomerId
        };
        await _cargoDetailService.CreateAsync(newCargoDetail);
        return Ok("Cargo detail created successfully!");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
    {
        var updatedCargoDetail = new CargoDetail
        {
            Barcode = updateCargoDetailDto.Barcode,
            CompanyId = updateCargoDetailDto.CompanyId,
            ReceiverCustomerId = updateCargoDetailDto.ReceiverCustomerId,
            SenderCustomerId = updateCargoDetailDto.SenderCustomerId,
            Id = updateCargoDetailDto.Id
        };
        await _cargoDetailService.UpdateAsync(updatedCargoDetail);
        return Ok("Cargo detail updated succesffully!");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteCargoDetail(int id)
    {
        await _cargoDetailService.DeleteAsync(id);
        return Ok("Cargo detail deleted successfully!");
    }

}
