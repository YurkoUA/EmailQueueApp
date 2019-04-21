using System;

namespace EmailQueueApp.Infrastructure.Interfaces
{
    public interface IEmailSender : IDisposable
    {
        void Send(string email, string subject, string text);
    }
}
