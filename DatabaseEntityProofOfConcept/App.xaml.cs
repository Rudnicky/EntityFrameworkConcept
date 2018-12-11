using DatabaseEntityProofOfConcept.Interfaces;
using DatabaseEntityProofOfConcept.Utils;
using DatabaseEntityProofOfConcept.ViewModels;
using System.Windows;
using Unity;

namespace DatabaseEntityProofOfConcept
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            UnityContainerSetup();
        }

        private void UnityContainerSetup()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IDisplayRecordsWindowViewModel, DisplayRecordsWindowViewModel>();
            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();

            var mainWindowViewModel = container.Resolve<MainWindowViewModel>();
            var window = new MainWindow { DataContext = mainWindowViewModel };
            window.Show();
        }
    }
}
