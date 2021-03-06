﻿using System;
using EmailQueueApp.Infrastructure.Database;

namespace EmailQueueApp.Infrastructure.Interfaces
{
    public interface IInternalRequestContext : IDisposable
    {
        /// <summary>
        /// Gets instance of ORM entity
        /// </summary>
        IDbContext DataContext { get; }

        /// <summary>
        /// Gets an instance of current logger
        /// </summary>
        //ILogger Logger { get; }

        /// <summary>
        /// Gets an instance of domain model /repository factory
        /// </summary>
        IServiceProviderFactory Factory { get; }
    }
}
