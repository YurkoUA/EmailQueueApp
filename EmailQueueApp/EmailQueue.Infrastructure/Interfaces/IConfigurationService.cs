using System;

namespace EmailQueueApp.Infrastructure.Interfaces
{
    public interface IConfigurationService : IDisposable
    {
        string GetDatabaseName();
        string GetDefaultConnectionString();
        SmtpConfiguration GetSmtpConfiguration();
    }
}
