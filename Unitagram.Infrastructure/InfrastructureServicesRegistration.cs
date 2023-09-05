using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unitagram.Application.Contracts.Logging;
using Unitagram.Infrastructure.Logging;

namespace Unitagram.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        return services;
    }
}