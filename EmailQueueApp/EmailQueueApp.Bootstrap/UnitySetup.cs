using System;
using EmailQueueApp.Infrastructure.Interfaces;
using Microsoft.Practices.Unity;

namespace EmailQueueApp.Bootstrap
{
    public static class UnitySetup
    {
        private static IUnityContainer _container;

        private static IUnityContainer container
        {
            get
            {
                if (_container == null)
                {
                    _container = new UnityContainer();
                    RegisterTypes(_container);
                }
                return _container;
            }
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            UnityDependencyResolver.RegisterTypes(container);
        }

        public static IUnityContainer GetUnityConfig()
        {
            return container;
        }

        public static IServiceProviderFactory CreateFactory(IInternalRequestContext context)
        {
            return new ServiceProviderFactory(container, context);
        }
    }
}
