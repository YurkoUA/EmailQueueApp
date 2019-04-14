using System;
using System.Collections.Generic;
using EmailQueueApp.ViewModel;
using EmailQueueApp.ViewModel.Enums;

namespace EmailQueueApp.Infrastructure.Services
{
    public interface IMailingService : IDisposable
    {
        MailingVM CreateMailing(CreateMailingPM mailing);
        IEnumerable<MailingReportAddressVM> GetReport();
        void UpdateStatus(int mailingAddressId, MailStatus status);
    }
}
