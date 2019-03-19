using Microsoft.Practices.Unity;
using EmailQueueApp.Business.Services;
using EmailQueueApp.Data.Repositories;
using EmailQueueApp.Infrastructure.Repositories;
using EmailQueueApp.Infrastructure.Services;

namespace EmailQueueApp.Bootstrap
{
    public class UnityDependencyResolver
    {
        protected static IUnityContainer _container;

        public static void RegisterTypes(IUnityContainer container)
        {
            _container = container;

            _container.RegisterType<IMailingRepository, MailingRepository>();
            _container.RegisterType<IMailingService, MailingService>();
        }
    }
}
