using System.Windows;
using TodoSyncApp.Client.ViewModels;

namespace TodoSyncApp.Client.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            var viewModel = new LoginViewModel();
            DataContext = viewModel;

            viewModel.LoginSucceeded += OnLoginSucceeded;
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.Password = PasswordBox.Password;
                vm.LoginCommand.Execute(null);
            }
        }

        private void OnLoginSucceeded(object sender, System.EventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
