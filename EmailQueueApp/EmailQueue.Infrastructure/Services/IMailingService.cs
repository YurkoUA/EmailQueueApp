using System;
using System.Collections.Generic;
using EmailQueueApp.ViewModel;

namespace EmailQueueApp.Infrastructure.Services
{
    public interface IMailingService : IDisposable
    {
        MailingVM CreateMailing(CreateMailingPM mailing);
        IEnumerable<MailingReportAddressVM> GetReport();
    }
}
