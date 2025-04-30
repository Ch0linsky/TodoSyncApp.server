using System.Windows;
using TodoSyncApp.Client.ViewModels;

namespace TodoSyncApp.Client.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
