using Unitagram.Application.Models.Email;

namespace Unitagram.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}