using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceAralık.Order.Application.Services;
public static class MediatorService
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatorService).Assembly));
    }
}
