using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Unitagram.Application;
using Unitagram.Identity;
using Unitagram.Infrastructure;
using Unitagram.Persistence;

namespace Unitagram.WebAPI.StartupExtensions;

/// <summary>
/// Configure Startup(Program) services class
/// </summary>
public static class ConfigureServiceExtension
{
    /// <summary>
    /// Configures services for the application.
    /// </summary>
    /// <param name="services">The collection of services to configure.</param>
    /// <param name="configuration">The configuration data for the application.</param>
    /// <param name="environment">The current web host environment.</param>
    /// <returns>The configured services collection.</returns>
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        // load configuration settings
        services.AddControllers(options =>
        {
            //Authorization policy
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme) // If you do not add AuthenticationScheme you will get an error for invalid JWT tokens
                .Build();
            options.Filters.Add(new AuthorizeFilter(policy));
        });

        // Enable API versioning
        services.AddApiVersioning(config =>
        {
            config.ApiVersionReader = new UrlSegmentApiVersionReader();

            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
        });

        if (environment.IsDevelopment() || environment.IsProduction())
        {
            // Add Swagger
            services.AddEndpointsApiExplorer(); // generates description for all endpoints
            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Test web API",
                    Version = "1.0"
                });

                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Test web API",
                    Version = "2.0"
                });

            }); // generates Open API specification
        }

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices();
        services.AddPersistenceServices(configuration);
        services.AddIdentityServices(configuration);
            
        return services;
    }
}