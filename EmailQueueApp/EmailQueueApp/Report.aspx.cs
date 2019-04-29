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
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<MailingReportAddressVM> ReportGrid_GetData()
        {
            using (var service = Factory.GetService<IMailingService>(RequestContext))
            {
                return service.GetReport().AsQueryable();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ReportGrid_DeleteItem(int id)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ReportGrid_UpdateItem(int id)
        {
            EmailQueueApp.ViewModel.MailingReportAddressVM item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

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

        }
    }
}