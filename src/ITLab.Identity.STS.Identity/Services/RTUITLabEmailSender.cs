using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITLab.Identity.STS.Identity.Services
{
    public class RTUITLabEmailSender : Microsoft.AspNetCore.Identity.UI.Services.IEmailSender
    {
        private readonly RTUITLab.EmailService.Client.IEmailSender emailSender;

        public RTUITLabEmailSender(RTUITLab.EmailService.Client.IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return emailSender.SendEmailAsync(email, subject, htmlMessage);
        }
    }
}
