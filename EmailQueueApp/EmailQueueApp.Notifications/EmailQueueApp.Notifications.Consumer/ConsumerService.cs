using System.ServiceProcess;
using EmailQueueApp.Infrastructure.Interfaces;
using EmailQueueApp.Notifications.Consumer.Context;


namespace EmailQueueApp.Notifications.Consumer
{
    public partial class ConsumerService : ServiceBase
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

        public ConsumerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MessageListener.Start();
        }

        protected override void OnStop()
        {
            MessageListener.Stop();
        }
    }
}
