using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailQueueApp.Infrastructure.Interfaces;
using EmailQueueApp.Infrastructure.Repositories;
using EmailQueueApp.Infrastructure.Services;
using EmailQueueApp.ViewModel;

namespace EmailQueueApp.Business.Services
{
    public class MailingService : ServiceBase, IMailingService
    {
        public MailingService(IRequestContext requestContext) : base(requestContext)
        {
        }

        public MailingVM CreateMailing(MailingVM mailing)
        {
            using (var repo = Factory.GetService<IMailingRepository>())
            {
                throw new NotImplementedException();
            }
        }
    }
}
