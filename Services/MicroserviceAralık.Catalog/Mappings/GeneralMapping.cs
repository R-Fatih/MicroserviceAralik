using AutoMapper;
using MicroserviceAralık.Catalog.Dtos.BrandDtos;
using MicroserviceAralık.Catalog.Dtos.CategoryDtos;
using MicroserviceAralık.Catalog.Dtos.ProductDetailDtos;
using MicroserviceAralık.Catalog.Dtos.ProductDtos;
using MicroserviceAralık.Catalog.Entities;

namespace MicroserviceAralık.Catalog.Mappings;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Brand, CreateBrandDto>().ReverseMap();
        CreateMap<Brand, ResultBrandDto>().ReverseMap();
        CreateMap<Brand, UpdateBrandDto>().ReverseMap();

        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();

        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();

        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
    }
}
