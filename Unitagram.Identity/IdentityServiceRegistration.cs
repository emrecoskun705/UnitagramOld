using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Unitagram.Application.Contracts.Identity;
using Unitagram.Application.Models.Identity;
using Unitagram.Identity.DbContext;
using Unitagram.Identity.Models;
using Unitagram.Identity.Services;

namespace Unitagram.Identity;

public static class IdentityServiceRegistration
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.AddDbContext<UnitagramIdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        //add identity
        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
            .AddEntityFrameworkStores<UnitagramIdentityDbContext>()
            .AddDefaultTokenProviders()
            .AddUserStore<UserStore<ApplicationUser, ApplicationRole, UnitagramIdentityDbContext, Guid>>()
            .AddRoleStore<RoleStore<ApplicationRole, UnitagramIdentityDbContext, Guid>>();

        services.AddTransient<IJwtService, JwtService>();
        services.AddTransient<IAuthService, AuthService>();

        // Add JWT
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtConfig = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>()!;

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidAudience = jwtConfig.Audience,
                    ValidateIssuer = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtConfig.Key)),
                };
            });
        
        services.AddAuthorization();

        return services;
    }
}