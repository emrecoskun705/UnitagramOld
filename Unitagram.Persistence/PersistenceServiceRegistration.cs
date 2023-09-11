using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unitagram.Application.Contracts.Persistence;
using Unitagram.Persistence.DatabaseContext;
using Unitagram.Persistence.Repositories;

namespace Unitagram.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<UnitagramDatabaseContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUniversityRepository, UniversityRepository>();
        services.AddScoped<IUniversityUserRepository, UniversityUserRepository>();
        services.AddScoped<IOtpConfirmationRepository, OtpConfirmationRepository>();

        return services;
    }
}