using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using MicroserviceAralık.Cargo.DtoLayer.Dtos.CustomerDtos;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Cargo.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomersController(ICustomerService _customerService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var result = await _customerService.GetAllAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var result = await _customerService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerDto dto)
    {
        var customer = new Customer
        {
            Address = dto.Address,
            Email = dto.Email,
            Name = dto.Name,
            Phone = dto.Phone,
            City = dto.City,
            District = dto.District,
            Surname = dto.Surname,
            UserCustomerId = dto.UserCustomerId,
        };
        await _customerService.CreateAsync(customer);
        return Ok("Customer created successfully!");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto dto)
    {
        var customer = new Customer
        {
            Address = dto.Address,
            Email = dto.Email,
            Name = dto.Name,
            Phone = dto.Phone,
            City = dto.City,
            District = dto.District,
            Surname = dto.Surname,
            UserCustomerId = dto.UserCustomerId,
            Id = dto.Id
        };
        await _customerService.UpdateAsync(customer);
        return Ok("Customer updated successfully!");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        await _customerService.DeleteAsync(id);
        return Ok("Customer deleted successfully!");
    }
}
