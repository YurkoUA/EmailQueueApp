using EmailQueueApp.Data.Entity;
using System;

namespace EmailQueueApp.Infrastructure.Repositories
{
    public interface IMailingRepository : IRepository, IDisposable
    {
        MailingEM CreateMailing(MailingEM mailing);
    }
}
