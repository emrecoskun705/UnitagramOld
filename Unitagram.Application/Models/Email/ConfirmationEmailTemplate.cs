namespace Unitagram.Application.Models.Email;

public static class ConfirmationEmailTemplate
{
    public static EmailMessage ToEmailMessage(string to, string code)
    {
        return new EmailMessage
        {
            To = to,
            Subject = "Hesap Onay Kodunuz: Unitagram",
            Body = $"""
            <!DOCTYPE html>
            <html lang="tr">
            <head>
                <meta charset="UTF-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <title>E-posta Onayı</title>
            </head>
            <body>
                <table style="max-width: 600px; margin: 0 auto; padding: 20px; font-family: Arial, sans-serif;">
                    <tr>
                        <td align="center">
                            <h2>E-posta Onayı</h2>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <p>Uygulamamıza kaydınız için teşekkür ederiz. Kaydınızı tamamlamak için lütfen aşağıdaki 6 haneli kodu girin:</p>
                            <h3 style="font-size: 24px; color: #007bff;">{code}</h3>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <p>Eğer bu kodu istememişseniz, bu e-postayı dikkate almayınız.</p>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <p>Unitagram'ı seçtiğiniz için teşekkür ederiz!</p>
                        </td>
                    </tr>
                </table>
            </body>
            </html>
            """
        };
    }
}