using EmailQueueApp.Data.Entity;

namespace EmailQueueApp.Infrastructure.Repositories
{
    public interface IMailingRepository : IRepository
    {
        MailingEM CreateMailing(MailingEM mailing);
    }
}
