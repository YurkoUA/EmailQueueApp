using System;
using EmailQueueApp.Infrastructure.Interfaces;

namespace EmailQueueApp.Business
{
    public abstract class InternalServiceBase : IDisposable
    {
        private readonly IInternalRequestContext context;

        public InternalServiceBase(IInternalRequestContext requestContext)
        {
            context = requestContext;
        }

        public IServiceProviderFactory Factory => context.Factory;

        public void Dispose()
        {
        }
    }
}
