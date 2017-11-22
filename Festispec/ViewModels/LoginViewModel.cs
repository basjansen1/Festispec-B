using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using Festispec.State;

namespace Festispec.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILoginRepositoryFactory _iLoginRepositoryFactory;

        public ICommand _loginCommand { get; set; }

        private IState _state;

        public Employee Employee { get; set; }
        public LoginViewModel(ILoginRepositoryFactory iLoginRepositoryFactory, IState state)
        {
            _iLoginRepositoryFactory = iLoginRepositoryFactory;
            _state = state;

            _loginCommand = new RelayCommand<PasswordBox>(Login);

            Employee = new Employee();
        }

        private void Login(PasswordBox passwordBox)
        {
            //Code so you don't need to enter username and password each run
            var password = passwordBox.Password;           
            if (Employee.Username == null) Employee.Username = "Minke";
            if (passwordBox.Password == "") password = "Minke123";


            Domain.Employee foundEmployee;
            var employee = new Employee()
            {
                Username = Employee.Username,
                //TODO: Change to passwordBox.Password in demo/live
                Password = password
            };

            using (var loginRepository = _iLoginRepositoryFactory.CreateRepository())
            {
                foundEmployee = loginRepository.Find(s => s.Username.Equals(employee.Username) && s.Password.Equals(employee.Password));              
            }
            if (foundEmployee != null)
            {
                _state.CurrentUser = foundEmployee;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else MessageBox.Show("Gebruikersnaam of wachtwoord is verkeerd");

        }
    }
}
