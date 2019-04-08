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
    public partial class Report : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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

        protected void ReportGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList dropDown = (e.Row.FindControl("StatusDropDown") as DropDownList);
                
                foreach (var item in Enum.GetValues(typeof(MailStatus)))
                {
                    dropDown.Items.Add(new ListItem(Enum.GetName(typeof(MailStatus), item), item.ToString()));
                }
            }
        }
    }
}