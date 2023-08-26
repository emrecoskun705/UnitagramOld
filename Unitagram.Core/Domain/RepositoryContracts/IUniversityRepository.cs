using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unitagram.Core.Domain.Entities;

namespace Unitagram.Core.Domain.RepositoryContracts
{
    public interface IUniversityRepository
    {
        /// <summary>
        /// Gets university by universityName parameter
        /// </summary>
        /// <param name="universityName">Name of the univeristy</param>
        /// <returns></returns>
        Task<University?> GetUniversityByDomainAsync(string domain);
    }
}
