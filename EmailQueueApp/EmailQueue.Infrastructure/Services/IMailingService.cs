using System;
using EmailQueueApp.ViewModel;

namespace EmailQueueApp.Infrastructure.Services
{
    public interface IMailingService : IDisposable
    {
        MailingVM CreateMailing(CreateMailingPM mailing);
    }
}
