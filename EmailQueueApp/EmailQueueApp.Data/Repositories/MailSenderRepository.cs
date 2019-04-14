using System.Collections.Generic;
using Dapper;
using EmailQueueApp.Data.Entity;
using EmailQueueApp.Infrastructure;
using EmailQueueApp.Infrastructure.Database;
using EmailQueueApp.Infrastructure.Extensions;
using EmailQueueApp.Infrastructure.Repositories;

namespace EmailQueueApp.Data.Repositories
{
    public class MailSenderRepository : DapperRepository, IMailSenderRepository
    {
        public MailSenderRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ServiceMailEM> GetSendData()
        {
            var data = ExecuteSP<ServiceMailEM>("USPGetSendData");
            return data;
        }

        public void UpdateStatus(IEnumerable<MessageStatusEM> statusInfo)
        {
            var sqlParams = new DynamicParameters();
            var statusParam = statusInfo.AsDataTableParam().AsTableValuedParameter(Constants.MESSAGE_STATUS_TYPE);
            ExecuteSP("USPServiceUpdateStatus", sqlParams);
        }

        public void Dispose()
        {
        }
    }
}
