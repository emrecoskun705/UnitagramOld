using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unitagram.Application.Contracts.Email;
using Unitagram.Application.Contracts.Logging;
using Unitagram.Application.Models.Email;
using Unitagram.Infrastructure.EmailService;
using Unitagram.Infrastructure.Logging;

namespace Unitagram.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddTransient<IEmailSender, EmailSender>();
        return services;
    }
}