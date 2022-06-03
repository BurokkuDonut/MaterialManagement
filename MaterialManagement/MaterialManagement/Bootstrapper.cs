using System.Windows;
using Caliburn.Micro;
using MaterialManagement.ViewModels;

namespace MaterialManagement
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        
        protected override void OnStartup(object sender, StartupEventArgs startupEventArgs)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        
    }
}