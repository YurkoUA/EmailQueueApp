using System.Web.UI;
using EmailQueueApp.Bootstrap;
using EmailQueueApp.Infrastructure.Interfaces;

namespace EmailQueueApp.Infrastructure
{
    public abstract class BasePage : Page
    {
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

        public void Refresh()
        {
            Redirect(Page.Request.Url.ToString());
        }

        public void Redirect(string url)
        {
            Page.Response.Redirect(url, true);
        }
    }
}