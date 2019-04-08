using System;
using System.Collections.Generic;
using EmailQueueApp.Data.Entity;

namespace EmailQueueApp.Infrastructure.Repositories
{
    public interface IMailingRepository : IRepository, IDisposable
    {
        MailingEM CreateMailing(MailingEM mailing);
        IEnumerable<MailingReportAddressEM> GetReport();
    }
}
