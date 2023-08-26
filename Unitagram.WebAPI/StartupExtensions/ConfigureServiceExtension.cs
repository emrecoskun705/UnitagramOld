using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Unitagram.Core.Domain.Identity;
using Unitagram.Core.ServiceContracts;
using Unitagram.Core.Services;
using Unitagram.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Unitagram.Core.Domain.RepositoryContracts;
using Unitagram.Infrastructure.Repositories;

namespace Unitagram.WebAPI.StartupExtensions
{
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
            services.AddControllers(options =>
            {
                //Authorization policy
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme) // If you do not add AuthenticationScheme you will get an error for invalid JWT tokens
                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            // Add JWT Service
            services.AddTransient<IJwtService, JwtService>();

            // Add Services to IoC container
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IUniversityGetterService, UniversityGetterService>();

            // Enable API versioning
            services.AddApiVersioning(config =>
            {
                config.ApiVersionReader = new UrlSegmentApiVersionReader();

                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });

            // Add Default database connection
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
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

            //add identity
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders()
              .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
              .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();


            // Add JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidateAudience = true,
                      ValidAudience = configuration["Jwt:Audience"],
                      ValidateIssuer = true,
                      ValidIssuer = configuration["Jwt:Issuer"],
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                  };
              });

            services.AddAuthorization();

            return services;
        }
    }
}
