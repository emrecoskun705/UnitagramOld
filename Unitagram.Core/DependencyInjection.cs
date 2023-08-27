using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unitagram.Core.ServiceContracts;
using Unitagram.Core.Services;

namespace Unitagram.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            // Add JWT Service
            services.AddTransient<IJwtService, JwtService>();

            // Add Services to IoC container
            services.AddScoped<IUniversityGetterService, UniversityGetterService>();

            return services;
        }
    }
}
