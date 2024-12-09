using MicroserviceAralık.Catalog.Dtos.ProductDtos;

namespace MicroserviceAralık.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProducts();
    Task<ResultProductDto> GetProductById(string id);
    Task CreateProduct(CreateProductDto dto);
    Task UpdateProduct(UpdateProductDto dto);
    Task DeleteProduct(string id);
}
