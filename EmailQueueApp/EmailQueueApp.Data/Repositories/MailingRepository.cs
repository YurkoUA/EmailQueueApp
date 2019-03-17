using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using EmailQueueApp.Data.Entity;
using EmailQueueApp.Infrastructure;
using EmailQueueApp.Infrastructure.Database;
using EmailQueueApp.Infrastructure.Extensions;
using EmailQueueApp.Infrastructure.Repositories;

namespace EmailQueueApp.Data.Repositories
{
    public class MailingRepository : DapperRepository, IMailingRepository
    {
        public MailingRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public MailingEM CreateMailing(MailingEM mailing)
        {
            var sqlParams = new DynamicParameters();
            var addresses = mailing.Adresses.AsDataTableParam().AsTableValuedParameter(Constants.MailingAddressType);

            sqlParams.Add("Subject", mailing.Subject, DbType.String);
            sqlParams.Add("Body", mailing.Body, DbType.String);
            sqlParams.Add("SendingTime", mailing.SendingTime, DbType.DateTime);
            sqlParams.Add("Addresses", addresses);

            using (IDbConnection db = new SqlConnection(dbContext.ConnectionString))
            {
                db.Open();

                using (var multi = db.QueryMultiple("USPCreateMailing", sqlParams, commandType: CommandType.StoredProcedure))
                {
                    mailing.Id = multi.Read<int>().First();
                    var addr = multi.Read<MailingAddressEM>().ToList();

                    addr.ForEach(a =>
                    {
                        mailing.Adresses.FirstOrDefault(ad => ad.Email.Equals(a.Email)).Id = a.Id;
                    });
                }
            }

            return mailing;
        }
    }
}
