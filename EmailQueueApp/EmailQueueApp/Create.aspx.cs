using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmailQueueApp.ViewModel;

namespace EmailQueueApp
{
    public partial class Create : Page
    {
        private CreateMailingPM pageModel = new CreateMailingPM();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void Addresses_UpdateItem(int id)
        {
            EmailQueueApp.ViewModel.AddressPM item = null;
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

        // The id parameter name should match the DataKeyNames value set on the control
        public void Addresses_DeleteItem(int id)
        {

        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {

        }

        public IQueryable<AddressPM> Addresses_GetData()
        {
            return new List<AddressPM>().AsQueryable();
        }
    }
}