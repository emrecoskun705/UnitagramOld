using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Unitagram.Core.Helpers
{
    public static class UniversityHelper
    {
        internal static string? GetUniversityDomainFromMail(string mail)
        {
            if(!IsValidEmail(mail))
                return null;

            string? domain = GetDomainFromEmail(mail);

            return domain;
        }

        internal static bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        internal static string? GetDomainFromEmail(string email)
        {
            Match match = Regex.Match(email, @"@([\w.-]+)$");

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }
    }
}
