﻿using Microsoft.Practices.Unity;
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

            _container.RegisterType<IDbContext, DbContext>(new InjectionConstructor(AppConfigurationHelper.GetConnectionString("DefaultConnection")));

            _container.RegisterType<IMailingRepository, MailingRepository>();
            _container.RegisterType<IMailingService, MailingService>();

            _container.RegisterType<IMappingService, MappingService>();
        }
    }
}
