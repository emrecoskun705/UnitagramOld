using Microsoft.EntityFrameworkCore;
using Unitagram.Application.Contracts.Persistence;
using Unitagram.Domain;
using Unitagram.Persistence.DatabaseContext;

namespace Unitagram.Persistence.Repositories;

public class UniversityRepository : GenericRepository<University>, IUniversityRepository
{
    public UniversityRepository(UnitagramDatabaseContext context) : base(context)
    {
    }

    public async Task<University?> GetByDomainAsync(string domain)
    {
        var university = await _context.University
            .Where(u => u.Domain == domain)
            .FirstOrDefaultAsync();
        
        return university;
    }
}