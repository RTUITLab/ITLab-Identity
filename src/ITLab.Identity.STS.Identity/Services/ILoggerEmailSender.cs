
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ITLab.Identity.STS.Identity.Services
{
    public class LoggerEmailSender : Microsoft.AspNetCore.Identity.UI.Services.IEmailSender
    {
        private readonly ILogger<LoggerEmailSender> logger;

        public LoggerEmailSender(ILogger<LoggerEmailSender> logger)
        {
            this.logger = logger;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            logger.LogInformation($"Send email to {email} subject: {subject} message: {htmlMessage}");
            return Task.CompletedTask;
        }
    }
}