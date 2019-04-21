using Newtonsoft.Json;
using EmailQueueApp.Data.Entity;
using EmailQueueApp.Infrastructure.Interfaces;
using EmailQueueApp.Infrastructure.Services;
using EmailQueueApp.Infrastructure.Repositories;
using EmailQueueApp.ViewModel.Enums;

namespace EmailQueueApp.Business.Services
{
    public class ConsumerService : ServiceBase, IConsumerService
    {
        public ConsumerService(IRequestContext requestContext) : base(requestContext)
        {
        }

        public void Receive(string message)
        {
            var mailEm = JsonConvert.DeserializeObject<ServiceMailEM>(message);

            using (var emailSender = Factory.GetService<IEmailSender>())
            using (var repo = Factory.GetService<IMailSenderRepository>())
            {
                var statusEm = new MessageStatusEM
                {
                    Id = mailEm.Id
                };

                for (var i = 1; i <= mailEm.RepeatCount; i++)
                {
                    try
                    {
                        emailSender.Send(mailEm.Email, mailEm.Subject, mailEm.Body);
                        statusEm.StatusId = (int)MailStatus.Sent;
                    }
                    catch
                    {
                        statusEm.StatusId = (int)MailStatus.Error;
                    }
                    finally
                    {
                        repo.UpdateStatus(new[] { statusEm });
                    }
                }
            }
        }
    }
}
