using Microsoft.Practices.Unity;

namespace EmailQueueApp.Bootstrap
{
    public class UnityDependencyResolver
    {
        protected static IUnityContainer _container;

        public static void RegisterTypes(IUnityContainer container)
        {
            _container = container;
        }
    }
}
