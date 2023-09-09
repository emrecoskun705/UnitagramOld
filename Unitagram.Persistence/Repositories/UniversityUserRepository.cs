using Microsoft.EntityFrameworkCore;
using Unitagram.Application.Contracts.Persistence;
using Unitagram.Domain;
using Unitagram.Persistence.DatabaseContext;

namespace Unitagram.Persistence.Repositories;

public class UniversityUserRepository : GenericRepository<UniversityUser>, IUniversityUserRepository
{
    public UniversityUserRepository(UnitagramDatabaseContext context) : base(context)
    {
    }

    public async Task<UniversityUser?> GetByUserIdAsync(Guid userId)
    {
        var universityUser = await _context.UniversityUser
            .Where(u => u.UserId == userId)
            .FirstOrDefaultAsync();
        
        return universityUser;
    }
}