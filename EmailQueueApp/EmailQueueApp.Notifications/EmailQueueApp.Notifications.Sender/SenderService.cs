using System;
using System.Configuration;
using EmailQueueApp.Infrastructure.Config;
using EmailQueueApp.Infrastructure.Services;

namespace EmailQueueApp.Notifications.Sender
{
    public partial class SenderService : BaseService
    {
        private const string SQL_COMMAND_TIMEOUT = "SqlCommandTimeout";
        private SenderConfig senderConfig = new SenderConfig();

        public SenderService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            senderConfig.QueueHost = ConfigurationManager.AppSettings["queuehost"].ToString();
            ConfigureScheduler();
        }

        protected override void OnStop()
        {
            DisposeScheduler();
        }

        protected override void Send(object sender, EventArgs e)
        {
            using (var senderServ = RequestContext.Factory.GetService<IMailSenderService>(RequestContext))
            {
                senderServ.Send(senderConfig);
            }
        }
    }
}
