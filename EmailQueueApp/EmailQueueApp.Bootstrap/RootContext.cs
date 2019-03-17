using EmailQueueApp.Infrastructure.Database;
using EmailQueueApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EmailQueueApp.Bootstrap
{
    public class RootContext : HttpContextBase, IRequestContext
    {
        public RootContext()
        {
            Factory = UnitySetup.CreateFactory(this);
            DataContext = Factory.GetService<IDbContext>();
        }

        public string ApplicationPath => ApplicationPath;

        public IDbContext DataContext { get; set; }

        public IServiceProviderFactory Factory { get; set; }

        public void Dispose()
        {
        }
    }
}
