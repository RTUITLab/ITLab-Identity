using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using ITLab.Identity.STS.Identity.Configuration;
using MimeKit;
using MailKit.Net.Smtp;

namespace ITLab.Identity.STS.Identity.Services
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly MailkitConfiguration _configuration;

        public MailKitEmailSender(MailkitConfiguration configuration, ILogger<EmailSender> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogInformation($"Sending email: {email}, subject: {subject}, message: {htmlMessage}");
            try
            {
                var mail = new MimeMessage
                {
                    Subject = subject,
                    Body = new TextPart("html")
                    {
                        Text = htmlMessage
                    }
                };
                mail.From.Add(new MailboxAddress(_configuration.Login));
                mail.To.Add(new MailboxAddress(email));
                using (var client = new SmtpClient())
                {
                    client.Connect(_configuration.Host, _configuration.Port, _configuration.UseSSL);
                    
                    await client.AuthenticateAsync(_configuration.Login, _configuration.Password);
                    
                    await client.SendAsync(mail);
                    _logger.LogInformation($"Email: {email}, subject: {subject}, message: {htmlMessage} successfully sent");
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception {ex} during sending email: {email}, subject: {subject}");
                throw;
            }
        }
    }
}






