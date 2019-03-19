using EmailQueueApp.ViewModel;

namespace EmailQueueApp.Infrastructure.Services
{
    public interface IMailingService
    {
        MailingVM CreateMailing(MailingVM mailing);
    }
}
