using System;
using System.Collections.Generic;
using EmailQueueApp.Data.Entity;

namespace EmailQueueApp.Infrastructure.Repositories
{
    public interface IMailSenderRepository : IDisposable
    {
        IEnumerable<ServiceMailEM> GetSendData();
        void UpdateStatus(IEnumerable<MessageStatusEM> statusInfo);
    }
}
