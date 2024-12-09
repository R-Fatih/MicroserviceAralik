using MicroserviceAralık.Catalog.Mappings;
using MicroserviceAralık.Catalog.Services.BrandServices;
using MicroserviceAralık.Catalog.Services.CategoryServices;
using MicroserviceAralık.Catalog.Services.ProductDetailServices;
using MicroserviceAralık.Catalog.Services.ProductServices;
using MicroserviceAralık.Catalog.Settings;
using Microsoft.Extensions.Options;

namespace MicroserviceAralık.Catalog.Configurations;

public static class ServiceRegistrations
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IProductDetailService, ProductDetailService>();

        services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
        services.AddScoped<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
        services.AddAutoMapper(typeof(GeneralMapping));
    }
}
