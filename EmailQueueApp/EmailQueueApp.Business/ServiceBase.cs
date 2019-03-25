using System;
using EmailQueueApp.Infrastructure.Interfaces;

namespace EmailQueueApp.Business
{
    public abstract class ServiceBase : IDisposable
    {
        protected readonly IMappingService mappingService;
        private readonly IRequestContext context;

        public ServiceBase(IRequestContext requestContext)
        {
            context = requestContext;
            mappingService = context.Factory.GetService<IMappingService>();
        }

        public IServiceProviderFactory Factory => context.Factory;

        public void Dispose()
        {
        }
    }
}
