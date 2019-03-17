using System;

namespace EmailQueueApp.Infrastructure.Interfaces
{
    public interface IRequestContext : IInternalRequestContext, IDisposable
    {
        string ApplicationPath { get; }
    }
}
