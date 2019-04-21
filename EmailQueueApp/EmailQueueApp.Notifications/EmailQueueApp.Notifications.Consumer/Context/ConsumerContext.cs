using System.Configuration;
using EmailQueueApp.Bootstrap;
using EmailQueueApp.Infrastructure.Database;
using EmailQueueApp.Infrastructure.Interfaces;

namespace EmailQueueApp.Notifications.Consumer.Context
{
    public class ConsumerContext : IInternalRequestContext
    {
        private const string CONNECTION_KEY = "DefaultConnection";

        public IDbContext DataContext { get; private set; }
        public IServiceProviderFactory Factory { get; private set; }


        public ConsumerContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_KEY].ToString();

            Factory = UnitySetup.CreateFactory(this);
            DataContext = Factory.GetService<IDbContext>(connectionString);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
