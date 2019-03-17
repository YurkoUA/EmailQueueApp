using System;

namespace EmailQueueApp.Infrastructure.Interfaces
{
    public interface IRepositoryProvider : IServiceProvider
    {
        TService GetService<TService>(params object[] constructParams);
    }
}
