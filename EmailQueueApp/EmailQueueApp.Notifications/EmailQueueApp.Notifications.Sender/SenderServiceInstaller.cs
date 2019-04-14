using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace EmailQueueApp.Notifications.Sender
{
    [RunInstaller(true)]
    public partial class SenderServiceInstaller : Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller serviceProcessInstaller;

        public SenderServiceInstaller()
        {
            InitializeComponent();

            serviceProcessInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem                
            };

            serviceInstaller = new ServiceInstaller
            {
                StartType = ServiceStartMode.Manual,
                DisplayName = "EmailQueue Sender",
                ServiceName = "EmailQueueSenderService"
            };

            Installers.Add(serviceProcessInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
