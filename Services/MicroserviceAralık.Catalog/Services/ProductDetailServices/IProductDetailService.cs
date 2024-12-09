using MicroserviceAralık.Catalog.Dtos.ProductDetailDtos;

namespace MicroserviceAralık.Catalog.Services.ProductDetailServices;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GetAllProductDetails();
    Task<ResultProductDetailDto> GetProductDetailById(string id);
    Task CreateProductDetail(CreateProductDetailDto dto);
    Task UpdateProductDetail(UpdateProductDetailDto dto);
    Task DeleteProductDetail(string id);
}
