using Unitagram.Domain;

namespace Unitagram.Application.Contracts.Persistence;

public interface IUniversityRepository : IGenericRepository<University>
{
    /// <summary>
    /// Gets University using domain name of that university
    /// </summary>
    /// <param name="domain">Domain name of university</param>
    /// <returns>Returns University using domain name</returns>
    Task<University?> GetByDomainAsync(string domain);
}