using System;
using System.Web.UI;
using EmailQueueApp.Bootstrap;
using EmailQueueApp.Infrastructure.Interfaces;

namespace EmailQueueApp.Infrastructure
{
    public abstract class BasePage<TModel> : Page
    {
        protected TModel pageModel;

        private readonly object _mutex = new object();
        private IRequestContext _context = default(RootContext);

        protected IServiceProviderFactory Factory
        {
            get
            {
                lock (_mutex)
                {
                    return RequestContext.Factory;
                }
            }
        }

        public IRequestContext RequestContext
        {
            get
            {
                lock (_mutex)
                {
                    if (_context == null)
                    {
                        _context = new RootContext();
                    }
                    return _context;
                }
            }
        }

        public virtual void PageLoad() { }
        public virtual void PageLoadPostBack() { }
        public virtual void PageUnload() { }

        public void Refresh()
        {
            Redirect(Page.Request.Url.ToString());
        }

        public void Redirect(string url)
        {
            Page.Response.Redirect(url, true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["PageModel"] = null;
                PageLoadPostBack();
            }
            else
            {
                pageModel = (TModel)Session["PageModel"];
                PageLoad();
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Session["PageModel"] = pageModel;
            PageUnload();
        }
    }
}