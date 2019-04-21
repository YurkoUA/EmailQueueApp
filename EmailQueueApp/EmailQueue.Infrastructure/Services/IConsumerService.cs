using System;

namespace EmailQueueApp.Infrastructure.Services
{
    public interface IConsumerService : IDisposable
    {
        void Receive(string message);
    }
}
