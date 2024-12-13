using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using MicroserviceAralık.Cargo.DtoLayer.Dtos.CompanyDtos;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Cargo.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CompaniesController(ICompanyService _companyService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        var result = await _companyService.GetAllAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyById(int id)
    {
        var result = await _companyService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCompany(CreateCompanyDto dto)
    {
        var company = new Company
        {
            Name = dto.Name,
        };
        await _companyService.CreateAsync(company);
        return Ok("Company created successfully!");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCompany(UpdateCompanyDto dto)
    {
        var company = new Company
        {
            Id = dto.Id,
            Name = dto.Name
        };
        await _companyService.UpdateAsync(company);
        return Ok("Company update successfully!");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        await _companyService.DeleteAsync(id);
        return Ok("Company deleted successfully!");
    }
}
