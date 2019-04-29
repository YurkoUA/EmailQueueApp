using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmailQueueApp.Infrastructure;
using EmailQueueApp.Infrastructure.Services;
using EmailQueueApp.ViewModel;
using EmailQueueApp.ViewModel.Enums;

namespace EmailQueueApp
{
    public partial class Report : BasePage<object>
    {
        public IQueryable<MailingReportAddressVM> ReportGrid_GetData()
        {
            using (var service = Factory.GetService<IMailingService>(RequestContext))
            {
                return service.GetReport().AsQueryable();
            }
        }

        public IQueryable<KeyValueVM> StatusDropDown_GetData()
        {
            var values = Enum.GetValues(typeof(MailStatus));
            var enumList = new List<KeyValueVM>();

            foreach (var item in values)
            {
                enumList.Add(new KeyValueVM
                {
                    Key = ((int)item).ToString(),
                    Value = Enum.GetName(typeof(MailStatus), item)
                });
            }
            
            return enumList.AsQueryable();
        }

        protected void StatusDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = (sender as DropDownList)?.Parent?.Parent as GridViewRow;
            var itemId = row?.Cells?[0]?.Text;

            if (!string.IsNullOrWhiteSpace(itemId))
            {
                using (var service = Factory.GetService<IMailingService>(RequestContext))
                {
                    service.UpdateStatus(int.Parse(itemId), MailStatus.New);
                }
            }

            Refresh();
        }
    }
}