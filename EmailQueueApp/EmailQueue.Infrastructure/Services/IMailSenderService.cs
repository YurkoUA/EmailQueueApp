using System;
using EmailQueueApp.Infrastructure.Config;

namespace EmailQueueApp.Infrastructure.Services
{
    public interface IMailSenderService : IDisposable
    {
        void Send(SenderConfig config);
    }
}
