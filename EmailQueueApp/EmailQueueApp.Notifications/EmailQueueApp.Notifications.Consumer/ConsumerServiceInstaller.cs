using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace EmailQueueApp.Notifications.Consumer
{
    [RunInstaller(true)]
    public partial class ConsumerServiceInstaller : Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller serviceProcessInstaller;

        public ConsumerServiceInstaller()
        {
            InitializeComponent();

            serviceProcessInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            };

            serviceInstaller = new ServiceInstaller
            {
                StartType = ServiceStartMode.Manual,
                DisplayName = "EmailQueue Consumer",
                ServiceName = "EmailQueueConsumerService"
            };

            Installers.Add(serviceProcessInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
