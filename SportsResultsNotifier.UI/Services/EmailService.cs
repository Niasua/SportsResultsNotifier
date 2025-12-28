using Microsoft.Extensions.Options;
using SportsResultsNotifier.UI.Settings;
using System.Net;
using System.Net.Mail;

namespace SportsResultsNotifier.UI.Services;

public class EmailService
{
    private readonly EmailSettings _settings;

    public EmailService(IOptions<EmailSettings> options)
    {
        _settings = options.Value;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        using var smtp = new SmtpClient(_settings.SmtpServer, _settings.Port)
        {
            Credentials = new NetworkCredential(_settings.Username, _settings.Password),
            EnableSsl = _settings.EnableSsl
        };

        var mail = new MailMessage(_settings.From, to, subject, body);

        await smtp.SendMailAsync(mail);
    }
}
