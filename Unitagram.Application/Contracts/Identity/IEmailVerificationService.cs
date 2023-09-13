using LanguageExt;
using LanguageExt.Common;

namespace Unitagram.Application.Contracts.Identity;

public interface IEmailVerificationService
{
    Task<Result<Unit>> GenerateAsync(Guid userId);
    Task<Result<bool>> ValidateAsync(Guid userId,string token);
}