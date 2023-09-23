using LanguageExt;
using LanguageExt.Common;

namespace Unitagram.Application.Contracts.Identity;

public interface IEmailVerificationService
{
    Task<Result<Unit>> GenerateAsync(Guid userId, string email);
    Task<Result<Unit>> ValidateAsync(Guid userId,string token);
}