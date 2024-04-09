using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Contexts;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure;

public static class InfrastructureStartUp
{
    public static IServiceCollection TryAddInfrastructed(this IServiceCollection services)
    {
        services.TryAddScoped<UserDbContext, UserDbContext>();
        services.TryAddScoped<IUserRepository, UserRepository>();
        return services;
    }
}