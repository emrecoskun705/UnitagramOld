using Unitagram.Core.Domain.Entities;

namespace Unitagram.Core.Domain.RepositoryContracts
{
    public interface IUniversityRepository
    {
        /// <summary>
        /// Get university using domain name of that university
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        Task<University?> GetUniversityByDomainAsync(string domain);
    }
}
