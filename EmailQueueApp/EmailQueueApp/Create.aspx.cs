using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmailQueueApp.Infrastructure;
using EmailQueueApp.Infrastructure.Services;
using EmailQueueApp.ViewModel;

namespace EmailQueueApp
{
    public partial class Create : BasePage<CreateMailingPM>
    {
        public Create()
        {
            pageModel = new CreateMailingPM();
        }

        public override void PageLoad()
        {
            pageModel = Session["PageModel"] as CreateMailingPM;
            pageModel.Subject = SubjectTextBox.Text;
            pageModel.Body = BodyTextBox.Text;

            var isSuccess = DateTime.TryParse(SendingDatePicker.Text, out DateTime date);

            if (isSuccess)
            {
                pageModel.SendingTime = date;
            }
        }

        public override void PageUnload()
        {
            SubjectTextBox.Text = pageModel.Subject;
            BodyTextBox.Text = pageModel.Body;
            SendingDatePicker.Text = pageModel.SendingTime.ToString("D");
        }
        
        public void Addresses_UpdateItem(string guid)
        {
            var item = pageModel.Adresses.FirstOrDefault(a => a.Guid == guid);

            if (item != null)
            {
                TryUpdateModel(item);
            }
        }
        
        public void Addresses_DeleteItem(string guid)
        {
            var item = pageModel.Adresses.FirstOrDefault(a => a.Guid == guid);
            pageModel.Adresses.Remove(item);
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            using (var service = Factory.GetService<IMailingService>(RequestContext))
            {
                service.CreateMailing(pageModel);
            }

            Redirect("Report.aspx");
        }

        public IQueryable<AddressPM> Addresses_GetData()
        {
            return (Session["PageModel"] as CreateMailingPM ?? new CreateMailingPM()).Adresses.AsQueryable();
        }

        protected void AddressAddBtn_Click(object sender, EventArgs e)
        {
            var address = new AddressPM
            {
                Email = EmailAddressTextBox.Text,
                RepeatCount = int.Parse(RepeatCountTextBox.Text)
            };

            pageModel.Adresses.Add(address);

            EmailAddressTextBox.Text = string.Empty;
            RepeatCountTextBox.Text = string.Empty;

            AddressesGrid.DataBind();
        }
    }
}