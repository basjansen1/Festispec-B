using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Festispec.Domain.Repository.Factory.Interface;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Festispec.State;
using System.Diagnostics;
using Festispec.Domain.Encryption;

namespace Festispec.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILoginRepositoryFactory _iLoginRepositoryFactory;

        public ICommand LoginCommand { get; set; }

        private readonly IState _state;

        public Domain.Employee Employee { get; set; }
        public LoginViewModel(ILoginRepositoryFactory iLoginRepositoryFactory, IState state)
        {
            _iLoginRepositoryFactory = iLoginRepositoryFactory;
            _state = state;

            LoginCommand = new RelayCommand<PasswordBox>(Login);

            Employee = new Domain.Employee();
        }
        private void ShowPopup() //show if user is online or offline
        {
            if (!_state.IsOnline)
            {
                MessageBox.Show("You are offline! Welcome!");
            }
        }
        private void Login(PasswordBox passwordBox)
        {
            //Code so you don't need to enter username and password each run
            var password = passwordBox.Password;           
            if (Employee.Username == null) Employee.Username = "Minke";
            if (passwordBox.Password == "") password = "Minke123";


            Domain.Employee foundEmployee;
            var employee = new Domain.Employee()
            {
                Username = Employee.Username,
                //TODO: Change to passwordBox.Password in demo/live
                Password = Cryptography.Encrypt(password)
            };

            using (var loginRepository = _iLoginRepositoryFactory.CreateRepository())
            {
                foundEmployee = loginRepository.Find(s => s.Username.Equals(employee.Username) && s.Password.Equals(employee.Password));              
            }
            if (foundEmployee != null)
            {
                //cache database if online
                _state.CurrentUser = foundEmployee;
                var mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else MessageBox.Show("Gebruikersnaam of wachtwoord is verkeerd");

            ShowPopup(); 
        }

    }
}
