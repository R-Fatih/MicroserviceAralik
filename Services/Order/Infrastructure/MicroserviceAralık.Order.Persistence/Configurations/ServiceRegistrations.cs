using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Persistence.Context;
using MicroserviceAralık.Order.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceAralık.Order.Persistence.Configurations;
public static class ServiceRegistrations
{
    public static void AddGenericServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
    }
}
