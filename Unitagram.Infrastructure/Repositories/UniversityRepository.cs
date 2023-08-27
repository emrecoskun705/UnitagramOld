using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //var university = await _db.University
            //    .Where(u => u. == domain && !u.IsDeleted && u.IsActive)
            //    .FirstOrDefaultAsync();
            //return university;
            return null;
        }
    }
}
