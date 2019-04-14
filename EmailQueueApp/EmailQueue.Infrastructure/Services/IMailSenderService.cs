using System;

namespace EmailQueueApp.Infrastructure.Services
{
    public interface IMailSenderService : IDisposable
    {
        void Send();
    }
}
