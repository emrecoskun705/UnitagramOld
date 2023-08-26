using System;
using Unitagram.Core.DTO;

namespace Unitagram.Core.ServiceContracts
{
    public interface IUniversityGetterService
    {
        /// <summary>
        /// Returns university by using email address
        /// </summary>
        /// <param name="email">Email to search</param>
        /// <returns>Returns matching university or null</returns>
        Task<UniversityDTO?> GetUniversityByEmail(string email);
    }
}
