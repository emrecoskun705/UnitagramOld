using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using Unitagram.Application.Contracts.Email;
using Unitagram.Application.Contracts.Logging;
using Unitagram.Application.Models.Email;

namespace Unitagram.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    private readonly EmailSettings _emailSettings;
    private readonly IAppLogger<EmailSender> _appLogger;
    
    public EmailSender(IOptions<EmailSettings> emailSettings, IAppLogger<EmailSender> appLogger)
    {
        _appLogger = appLogger;
        _emailSettings = emailSettings.Value;
    }
    
    
    public Task<bool> SendEmail(EmailMessage emailMessage, bool isBodyHtml = false)
    {
        try
        {
            using SmtpClient smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort);
            smtpClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smtpClient.EnableSsl = true; // Enable SSL encryption

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_emailSettings.Email);
            mail.To.Add(emailMessage.To);
            mail.Subject = emailMessage.Subject;
            mail.Body = emailMessage.Body;

            mail.IsBodyHtml = isBodyHtml;

            smtpClient.Send(mail);
            return Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _appLogger.LogError("EmailError", ex);
            return Task.FromResult(false);
        }
    }
}