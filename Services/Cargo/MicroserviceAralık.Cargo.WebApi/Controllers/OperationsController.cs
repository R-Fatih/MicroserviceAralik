using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using MicroserviceAralık.Cargo.DtoLayer.Dtos.OperationDtos;
using Microsoft.AspNetCore.Mvc;
using Operation = MicroserviceAralık.Cargo.EntityLayer.Concrete.Operation;

namespace MicroserviceAralık.Cargo.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OperationsController(IOperationService _operationService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOperations()
    {
        var result = await _operationService.GetAllAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOperationById(int id)
    {
        var result = await _operationService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("GetOperationByBarcodeNumber")]
    public async Task<IActionResult> GetOperationByBarcodeNumber(string barcode)
    {
        var result = await _operationService.GetOperationsByBarcodeNumber(barcode);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOperation(CreateOperationDto dto)
    {
        var operation = new Operation
        {
            Barcode = dto.Barcode,
            Description = dto.Description,
            OperationTime = DateTime.UtcNow,

        };
        await _operationService.CreateAsync(operation);
        return Ok("Operation created successfully!");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateOperation(UpdateOperationDto dto)
    {
        var operation = new Operation
        {
            Barcode = dto.Barcode,
            Description = dto.Description,
            OperationTime = DateTime.UtcNow,
            Id = dto.Id
        };
        await _operationService.UpdateAsync(operation);
        return Ok("Operation updated successfully!");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteOperation(int id)
    {
        await _operationService.DeleteAsync(id);
        return Ok("Operation deleted successfully!");
    }
}
