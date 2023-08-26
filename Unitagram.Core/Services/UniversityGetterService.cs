using Microsoft.Extensions.Logging;
using Serilog;
using Unitagram.Core.Helpers;
using Unitagram.Core.Domain.RepositoryContracts;
using Unitagram.Core.DTO;
using Unitagram.Core.ServiceContracts;

namespace Unitagram.Core.Services
{
    public class UniversityGetterService : IUniversityGetterService
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly ILogger<UniversityGetterService> _logger;
        private readonly IDiagnosticContext _diagnosticsContext;

        public UniversityGetterService(
            IUniversityRepository universityRepository,
            ILogger<UniversityGetterService> logger,
            IDiagnosticContext diagnosticsContext)
        {
            _universityRepository = universityRepository;
            _logger = logger;
            _diagnosticsContext = diagnosticsContext;
        }

        public async Task<UniversityDTO?> GetUniversityByEmail(string email)
        {
            if(email == null) 
                throw new ArgumentNullException(nameof(email));

            var domain = UniversityHelper.GetUniversityDomainFromMail(email);

            if(domain == null)
                throw new ArgumentNullException(nameof(domain));

            var getUniversity = await _universityRepository.GetUniversityByDomainAsync(domain);

            if (getUniversity == null)
                return null;

            return getUniversity.ToUniversityDTO();
        }
    }
}
