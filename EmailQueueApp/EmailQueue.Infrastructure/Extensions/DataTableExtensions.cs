using System.Collections.Generic;
using System.Data;
using System.Linq;
using EmailQueueApp.Data.Entity;

namespace EmailQueueApp.Infrastructure.Extensions
{
    public static class DataTableExtensions
    {
        public static DataTable AsDataTableParam(this IEnumerable<MailingAddressEM> addresses)
        {
            var table = new DataTable();

            table.Columns.Add("Email");
            table.Columns.Add("RepeatCount");

            if (addresses?.Any() == true)
            {
                foreach (var item in addresses)
                {
                    table.Rows.Add(item.Email, item.RepeatCount);
                }
            }

            return table;
        }

        public static DataTable AsDataTableParam(this IEnumerable<MessageStatusEM> statusInfo)
        {
            var table = new DataTable();

            table.Columns.Add("MailingAddressId");
            table.Columns.Add("StatusId");

            if (statusInfo?.Any() == true)
            {
                foreach (var item in statusInfo)
                {
                    table.Rows.Add(item.Id, item.StatusId);
                }
            }

            return table;
        }
    }
}
