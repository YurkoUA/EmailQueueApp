﻿using System.Net;
using System.Net.Mail;
using EmailQueueApp.Infrastructure;
using EmailQueueApp.Infrastructure.Interfaces;

namespace EmailQueueApp.Business
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpConfiguration smtpConfiguration;

        public EmailSender(SmtpConfiguration smtpConfiguration)
        {
            this.smtpConfiguration = smtpConfiguration;
        }

        public void Send(string email, string subject, string text)
        {
            using (var client = new SmtpClient(smtpConfiguration.Server, smtpConfiguration.Port))
            {
                client.Credentials = new NetworkCredential(smtpConfiguration.Login, smtpConfiguration.Password);
                client.EnableSsl = true;

                var message = new MailMessage(smtpConfiguration.Login, email)
                {
                    Subject = subject,
                    Body = text,
                    IsBodyHtml = true
                };

                client.Send(message);
            }
        }

        public void Dispose()
        {
        }
    }
}
