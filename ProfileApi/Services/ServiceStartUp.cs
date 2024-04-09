using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Interfaces;
using Services.Services;

namespace Services;

public static class ServiceStartUp
{
    public static IServiceCollection TryAddService(this IServiceCollection services)
    {
        services.TryAddScoped<IUserService, UserService>();
        return services;
    }
}