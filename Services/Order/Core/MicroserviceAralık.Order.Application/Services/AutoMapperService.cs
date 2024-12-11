using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceAralık.Order.Application.Services;
public static class AutoMapperService
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
