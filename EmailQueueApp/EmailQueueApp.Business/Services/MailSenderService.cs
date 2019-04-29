using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using EmailQueueApp.Data.Entity;
using EmailQueueApp.Infrastructure;
using EmailQueueApp.Infrastructure.Interfaces;
using EmailQueueApp.Infrastructure.Repositories;
using EmailQueueApp.Infrastructure.Services;
using EmailQueueApp.ViewModel.Enums;
using EmailQueueApp.Infrastructure.Config;

namespace EmailQueueApp.Business.Services
{
    public class MailSenderService : InternalServiceBase, IMailSenderService
    {
        private List<MessageStatusEM> statuses = new List<MessageStatusEM>();

        public MailSenderService(IInternalRequestContext requestContext) : base(requestContext)
        {
        }

        public void Send(SenderConfig config)
        {
            using (var repo = Factory.GetService<IMailSenderRepository>())
            {
                var data = repo.GetSendData();
                Push(data, config);
            }
        }

        private void Push(IEnumerable<ServiceMailEM> mails, SenderConfig config)
        {
            var factory = new ConnectionFactory { HostName = config.QueueHost };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                mails.ToList().ForEach(m =>
                {
                    try
                    {
                        var messageText = JsonConvert.SerializeObject(m);

                        channel.QueueDeclare(Constants.EMAIL_QUEUE_NAME, false, false, false, null);
                        channel.BasicPublish(exchange: string.Empty, routingKey: Constants.EMAIL_QUEUE_NAME, basicProperties: null, body: Encoding.UTF8.GetBytes(messageText));

                        LogMessage(m);
                    }
                    catch
                    {
                        LogError(m);
                    }
                });

                UpdateStatuses();
            }
        }

        private void LogMessage(ServiceMailEM mail)
        {
            statuses.Add(new MessageStatusEM
            {
                Id = mail.Id,
                StatusId = (int)MailStatus.InQueue
            });
        }

        private void LogError(ServiceMailEM mail)
        {
            statuses.Add(new MessageStatusEM
            {
                Id = mail.Id,
                StatusId = (int)MailStatus.Error
            });
        }

        private void UpdateStatuses()
        {
            using (var repo = Factory.GetService<IMailSenderRepository>())
            {
                repo.UpdateStatus(statuses);
            }
        }
    }
}
