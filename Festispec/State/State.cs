using System;
using System.Linq;
using System.Windows;
using Festispec.Domain;
using Festispec.Routes;
using Festispec.Views;

namespace Festispec.State
{
    public class State : IState
    {
        public State()
        {
            IsOnline = CheckConnection();
        }

        public Route CurrrentRoute { get; set; }

        private Employee _currentEmployee;

        public Employee CurrentUser
        {
            get { return _currentEmployee; }
            set
            {
                _currentEmployee = value;

                if (_currentEmployee == null)
                {
                    MessageBox.Show("U bent uitgelogd.");

                    var loginWindow = new Login();
                    loginWindow.Show();
                    Application.Current.Windows.OfType<MainWindow>().FirstOrDefault()?.Close();
                }
            }
        }

        public bool IsOnline { get; private set; }

        private bool CheckConnection()
        {
            try
            {
                using (var dbContext = new FestispecContainer())
                {
                    return dbContext.Database.Exists();
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
