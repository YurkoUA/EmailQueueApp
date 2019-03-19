using System;
using EmailQueueApp.Infrastructure.Interfaces;

namespace EmailQueueApp.Business
{
    public abstract class ServiceBase : IDisposable
    {
        private readonly IRequestContext context;

        public ServiceBase(IRequestContext requestContext)
        {
            context = requestContext;
        }

        public IServiceProviderFactory Factory => context.Factory;

        public void Dispose()
        {
        }
    }
}
