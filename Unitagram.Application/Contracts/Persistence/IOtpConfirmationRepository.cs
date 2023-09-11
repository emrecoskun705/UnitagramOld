using Unitagram.Domain;

namespace Unitagram.Application.Contracts.Persistence;

public interface IOtpConfirmationRepository : IGenericRepository<OtpConfirmation>
{
    /// <summary>
    /// Retrieves an OTP confirmation by the user's unique identifier and name which are both primary keys.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="name">The name or identifier associated with the OTP confirmation.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result is an instance of OtpConfirmation
    /// if a matching confirmation is found; otherwise, it returns null.
    /// </returns>
    Task<OtpConfirmation?> GetByUserIdAndName(Guid userId, string name);
}