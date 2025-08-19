using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using Portfolio.Settings;

namespace Portfolio.Services;

public class ContactService
{
    private readonly EmailSettings _settings;
    public ContactService(IOptions<EmailSettings> options)
    {
        _settings = options.Value;
    }

    public async Task<bool> SendAsync(string name, string email, string message)
    {
        var mime = new MimeMessage();
        mime.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
        mime.To.Add(MailboxAddress.Parse(_settings.FromEmail));
        mime.Subject = $"Contato do site: {name} - {email}";
        mime.Body = new TextPart("plain") { Text = message };

        try
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(_settings.SmtpServer, _settings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_settings.SmtpUser, _settings.SmtpPass);
            await client.SendAsync(mime);
            await client.DisconnectAsync(true);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
