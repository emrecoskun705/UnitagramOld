using System.Globalization;

namespace Unitagram.Application.Exceptions.EmailVerification;

public class OtpCodeTryAgainLaterException : Exception
{
    public OtpCodeTryAgainLaterException(int minutesDifference) : base(minutesDifference.ToString(CultureInfo.InvariantCulture))
    {
    }
}