using System.Configuration;
using Microsoft.Practices.Unity;
using EmailQueueApp.Business;
using EmailQueueApp.Business.Services;
using EmailQueueApp.Data;
using EmailQueueApp.Data.Repositories;
using EmailQueueApp.Infrastructure.Repositories;
using EmailQueueApp.Infrastructure.Services;
using EmailQueueApp.Infrastructure.Interfaces;
using EmailQueueApp.Infrastructure.Util;
using EmailQueueApp.Infrastructure.Database;

namespace EmailQueueApp.Bootstrap
{
    public class UnityDependencyResolver
    {
        protected static IUnityContainer _container;

        public static void RegisterTypes(IUnityContainer container)
        {
            _container = container;

            _container.RegisterType<IDbContext, DbContext>(new InjectionConstructor(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            _container.RegisterType<IMailingRepository, MailingRepository>();
            _container.RegisterType<IMailSenderRepository, MailSenderRepository>();

            _container.RegisterType<IMailingService, MailingService>();
            _container.RegisterType<IMailSenderService, MailSenderService>();
            _container.RegisterType<IConsumerService, ConsumerService>();
            _container.RegisterType<IConfigurationService, ConfigurationService>(
                new InjectionConstructor(ConfigurationManager.AppSettings, ConfigurationManager.ConnectionStrings)
            );

            _container.RegisterType<IEmailSender, EmailSender>(new InjectionConstructor(_container.Resolve<IConfigurationService>().GetSmtpConfiguration()));

            _container.RegisterType<IMappingService, MappingService>();

            _container.RegisterType<IRequestContext, RootContext>();
        }
    }
}
