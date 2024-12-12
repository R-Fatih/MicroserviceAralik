using MicroserviceAralık.Catalog.Dtos.ProductDtos;
using MicroserviceAralık.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Catalog.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService _productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _productService.GetAllProducts();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var result = await _productService.GetProductById(id);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto dto)
    {
        await _productService.CreateProduct(dto);
        return Ok("Product created succesfully!");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
    {
        await _productService.UpdateProduct(dto);
        return Ok("Product updated succesfully!");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProduct(id);
        return Ok("Product deleted succesfully!");
    }
}
