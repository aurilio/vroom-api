using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vroom.Domain;

namespace Vroom.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DomainEntryPoint).Assembly));


        return services;
    }
}