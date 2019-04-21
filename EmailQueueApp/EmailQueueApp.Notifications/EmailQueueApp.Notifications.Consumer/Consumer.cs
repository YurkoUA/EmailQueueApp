using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using EmailQueueApp.Infrastructure.Interfaces;
using EmailQueueApp.Notifications.Consumer.Context;
using EmailQueueApp.Infrastructure.Services;

namespace EmailQueueApp.Notifications.Consumer
{
    public class Consumer : EventingBasicConsumer
    {
        private readonly object mutex = new object();
        private IInternalRequestContext context = default(IInternalRequestContext);

        public IInternalRequestContext RequestContext
        {
            get
            {
                lock (mutex)
                {
                    return context ?? (context = new ConsumerContext());
                }
            }
        }

        public Consumer(IModel model) : base(model)
        {
            base.Received += OnReceived;
        }

        private void OnReceived(object sender, BasicDeliverEventArgs e)
        {
            using (var service = RequestContext.Factory.GetService<IConsumerService>(RequestContext))
            {
                service.Receive(Encoding.UTF8.GetString(e.Body));
            }
        }
    }
}
