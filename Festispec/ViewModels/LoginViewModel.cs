using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.ViewModels.NavigationService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Festispec.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILoginRepositoryFactory _iLoginRepositoryFactory;

        public ICommand _loginCommand { get; set; }

        public Employee Employee { get; set; }
        public LoginViewModel(ILoginRepositoryFactory iLoginRepositoryFactory)
        {
            _iLoginRepositoryFactory = iLoginRepositoryFactory;

            _loginCommand = new RelayCommand<PasswordBox>(Login);

            Employee = new Employee();
        }

        private void Login(PasswordBox passwordBox)
        {
            Domain.Employee foundEmployee;
            var employee = new Employee()
            {
                Username = Employee.Username,
                Password = passwordBox.Password
            };

            using (var loginRepository = _iLoginRepositoryFactory.CreateRepository())
            {
                foundEmployee = loginRepository.Find(s => s.Username.Equals(employee.Username) && s.Password.Equals(employee.Password));
            }

            if (foundEmployee != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
                
            }

        }
    }
}
