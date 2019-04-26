using System;
using EmailQueueApp.Infrastructure.Services;

namespace EmailQueueApp.Notifications.Sender
{
    public partial class SenderService : BaseService
    {
        private const string SQL_COMMAND_TIMEOUT = "SqlCommandTimeout";

        public SenderService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
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
                senderServ.Send();
            }
        }
    }
}
