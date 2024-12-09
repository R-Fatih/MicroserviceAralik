using MicroserviceAralık.Catalog.Dtos.BrandDtos;

namespace MicroserviceAralık.Catalog.Services.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrands();
    Task<ResultBrandDto> GetBrandById(string id);
    Task CreateBrand(CreateBrandDto dto);
    Task UpdateBrand(UpdateBrandDto dto);
    Task DeleteBrand(string id);
}
