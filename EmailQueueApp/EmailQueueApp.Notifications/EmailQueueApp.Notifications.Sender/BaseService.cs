using System;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;
using EmailQueueApp.Infrastructure.Interfaces;
using EmailQueueApp.Notifications.Sender.Context;

namespace EmailQueueApp.Notifications.Sender
{
    public abstract class BaseService : ServiceBase
    {
        private const string RUN_INTERVAL_KEY = "runinterval";
        private readonly object mutex = new object();
        private IInternalRequestContext context = default(SenderContext);
        protected Timer scheduler;

        public BaseService()
        {
        }

        public IInternalRequestContext RequestContext
        {
            get
            {
                lock (mutex)
                {
                    if (context == null)
                    {
                        context = new SenderContext();
                    }
                }

                return context;
            }
        }

        protected abstract void Send(object sender, EventArgs e);
        
        protected virtual void ConfigureScheduler()
        {
            var runInterval = int.Parse(ConfigurationManager.AppSettings[RUN_INTERVAL_KEY]);
            scheduler = new Timer(runInterval);
            scheduler.Elapsed += new ElapsedEventHandler(Send);
            scheduler.Start();
        }

        protected virtual void DisposeScheduler()
        {
            scheduler.Stop();
            scheduler.Dispose();
        }
    }
}
