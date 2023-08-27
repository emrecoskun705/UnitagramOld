using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Unitagram.Core.Domain.Entities;
using Unitagram.Core.Domain.RepositoryContracts;
using Unitagram.Infrastructure.DatabaseContext;

namespace Unitagram.Infrastructure.Repositories
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<UniversityRepository> _logger;

        public UniversityRepository(ApplicationDbContext db, ILogger<UniversityRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<University?> GetUniversityByDomainAsync(string domain)
        {
            var universityDomain = (await _db.UniversityDomain
                .Where(ud => ud.Name == domain)
                .Include(ud => ud.University)
                .AsNoTracking()
                .FirstOrDefaultAsync());

            if (universityDomain == null)
                return null;

            var university = universityDomain.University;

            return university;
        }
    }
}
