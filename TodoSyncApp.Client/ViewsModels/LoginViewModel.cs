using System;
using System.Windows;
using System.Windows.Input;
using TodoSyncApp.Client.Helpers;

namespace TodoSyncApp.Client.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public event EventHandler LoginSucceeded;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            if (Username == "admin" && Password == "1234")
            {
                SessionManager.LoggedInUsername = Username;
                LoginSucceeded?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Credenciales inválidas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
