using System.Windows;
using TodoSyncApp.Client.Helpers;
using TodoSyncApp.Client.Views;

namespace TodoSyncApp.Client
{
    public partial class App : Application
    {
        public App()
        {
            // Iniciar con la ventana de inicio de sesión
            var loginWindow = new Views.LoginWindow();
            loginWindow.Show();
            Application.Current.MainWindow = loginWindow;
        }
    
    protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (SessionManager.LoadSession())
            {
                new MainWindow().Show();
            }
            else
            {
                var login = new LoginWindow();
                if (login.ShowDialog() == true)
                {
                    SessionManager.SaveSession();
                    new MainWindow().Show();
                }
                else
                {
                    Shutdown();
                }
            }
        }
    }

}
