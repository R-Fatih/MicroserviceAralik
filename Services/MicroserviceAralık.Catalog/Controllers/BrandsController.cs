using MicroserviceAralık.Catalog.Dtos.BrandDtos;
using MicroserviceAralık.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Catalog.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BrandsController(IBrandService _brandService) : ControllerBase
{

    [Authorize(Policy = "CatalogReadAccess")]
    [HttpGet]
    public async Task<IActionResult> GetAllBrands()
    {
        var result = await _brandService.GetAllBrands();
        return Ok(result);
    }
    [Authorize(Policy = "CatalogReadAccess")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandById(string id)
    {
        var result = await _brandService.GetBrandById(id);
        return Ok(result);
    }
    [Authorize(Policy = "CatalogFullAccess")]
    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
    {
        await _brandService.CreateBrand(dto);
        return Ok("Brand created succesfully!");
    }
    [Authorize(Policy = "CatalogFullAccess")]
    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto dto)
    {
        await _brandService.UpdateBrand(dto);
        return Ok("Brand updated succesfully!");
    }
    [Authorize(Policy = "CatalogFullAccess")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrand(id);
        return Ok("Brand deleted succesfully!");
    }
}
