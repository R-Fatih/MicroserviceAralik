using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using MicroserviceAralık.Cargo.BusinessLayer.Concrete;
using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Concrete;
using MicroserviceAralık.Cargo.DataAccessLayer.EntityFramework;
using MicroserviceAralık.Cargo.DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceAralık.Cargo.BusinessLayer.Extensions;
public static class ServiceRegistrations
{
    public static void RegisterBusinessLayer(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();

        services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
        services.AddScoped<ICargoDetailService, CargoDetailManager>();

        services.AddScoped<ICompanyDal, EfCompanyDal>();
        services.AddScoped<ICompanyService, CompanyManager>();

        services.AddScoped<ICustomerDal, EfCustomerDal>();
        services.AddScoped<ICustomerService, CustomerManager>();

        services.AddScoped<IOperationDal, EfOperationDal>();
        services.AddScoped<IOperationService, OperationManager>();

        services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

    }
}
