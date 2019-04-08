using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailQueueApp.Data.Entity;
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

        public MailingVM CreateMailing(CreateMailingPM mailing)
        {
            using (var repo = Factory.GetService<IMailingRepository>())
            {
                var mailingEm = mappingService.ConvertTo<MailingEM>(mailing);
                mailingEm = repo.CreateMailing(mailingEm);

                var mailingVM = mappingService.ConvertTo<MailingVM>(mailingEm);
                return mailingVM;
            }
        }

        public IEnumerable<MailingReportAddressVM> GetReport()
        {
            using (var repo = Factory.GetService<IMailingRepository>())
            {
                var addresses = repo.GetReport();
                return mappingService.ConvertCollectionTo<MailingReportAddressVM>(addresses);
            }
        }
    }
}
