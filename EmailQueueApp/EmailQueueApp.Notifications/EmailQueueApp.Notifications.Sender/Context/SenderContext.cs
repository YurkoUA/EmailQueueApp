using System;
using System.Configuration;
using EmailQueueApp.Bootstrap;
using EmailQueueApp.Infrastructure.Database;
using EmailQueueApp.Infrastructure.Interfaces;

namespace EmailQueueApp.Notifications.Sender.Context
{
    public class SenderContext : IInternalRequestContext
    {
        public SenderContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            Factory = UnitySetup.CreateFactory(this);
            DataContext = Factory.GetService<IDbContext>(connectionString);
        }

        public IDbContext DataContext { get; private set; }

        public IServiceProviderFactory Factory { get; private set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
