using MicroserviceAralık.Catalog.Dtos.ProductDetailDtos;
using MicroserviceAralık.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Catalog.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductDetailDetailsController(IProductDetailService _productDetailService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProductDetails()
    {
        var result = await _productDetailService.GetAllProductDetails();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var result = await _productDetailService.GetProductDetailById(id);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto dto)
    {
        await _productDetailService.CreateProductDetail(dto);
        return Ok("ProductDetail created succesfully!");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto dto)
    {
        await _productDetailService.UpdateProductDetail(dto);
        return Ok("ProductDetail updated succesfully!");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _productDetailService.DeleteProductDetail(id);
        return Ok("ProductDetail deleted succesfully!");
    }
}
