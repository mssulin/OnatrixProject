using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using OnatrixProject.Interfaces;
using OnatrixProject.ViewModels;

namespace OnatrixProject.Services;

/* Denna klass och allt som tillhör mailbekräftelse är genererad av Chat GPT 5 för att kunna
 mail om bekräftelse efter ifyllt formulär. Den använder sig av SMTP och Mailkit. 
 */

public class SmtpEmailService: IEmailService

{
    private readonly EmailViewModel _emailVm;

    public SmtpEmailService(IOptions<EmailViewModel> options)
    {
        _emailVm = options.Value;
    }


    // Mottagarens address, ämnesrad, innehåll och emailaddress att svara till.
    public async Task SendAsync(string toEmail, string subject, string body, string? replyTo = null)
    {
        var message = new MimeMessage();
        
        // Från
        message.From.Add(new MailboxAddress(_emailVm.FromName, _emailVm.FromAddress));

        // Till
        message.To.Add(MailboxAddress.Parse(toEmail));
        
        // Svara till
        if (!string.IsNullOrWhiteSpace(replyTo))
            message.ReplyTo.Add(MailboxAddress.Parse(replyTo));

        // Ämne och innehåll
        message.Subject = subject;
        message.Body = new BodyBuilder { HtmlBody = body }.ToMessageBody();

        // Skickas via Smtp
        using var smtp = new SmtpClient();
        
        // Server
        await smtp.ConnectAsync(_emailVm.Host, _emailVm.Port, MailKit.Security.SecureSocketOptions.StartTls, CancellationToken.None);
        
        // Gmail
        await smtp.AuthenticateAsync(_emailVm.User,  _emailVm.Password);
        
        // Skickar
        await smtp.SendAsync(message);
        await smtp.DisconnectAsync(true);
    }
}