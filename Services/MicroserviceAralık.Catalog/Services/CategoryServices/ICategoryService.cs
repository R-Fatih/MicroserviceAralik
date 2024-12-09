using MicroserviceAralık.Catalog.Dtos.CategoryDtos;

namespace MicroserviceAralık.Catalog.Services.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategories();
    Task<ResultCategoryDto> GetCategoryById(string id);
    Task CreateCategory(CreateCategoryDto dto);
    Task UpdateCategory(UpdateCategoryDto dto);
    Task DeleteCategory(string id);
}
