using MicroserviceAralık.Catalog.Dtos.CategoryDtos;
using MicroserviceAralık.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Catalog.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService _categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _categoryService.GetAllCategories();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var result = await _categoryService.GetCategoryById(id);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
    {
        await _categoryService.CreateCategory(dto);
        return Ok("Category created succesfully!");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
    {
        await _categoryService.UpdateCategory(dto);
        return Ok("Category update successfully!");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategory(id);
        return Ok("Category deleted successfully!");
    }
}
