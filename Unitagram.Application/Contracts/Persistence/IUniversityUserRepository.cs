using Unitagram.Domain;

namespace Unitagram.Application.Contracts.Persistence;

public interface IUniversityUserRepository : IGenericRepository<UniversityUser>
{
    Task<UniversityUser?> GetByUserIdAsync(Guid userId);
}