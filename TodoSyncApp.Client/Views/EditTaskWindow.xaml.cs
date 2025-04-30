using System.Windows;
using System.Windows.Media.Animation;
using TodoSyncApp.Client.ViewModels;

namespace TodoSyncApp.Client.Views
{
    public partial class EditTaskWindow : Window
    {
        public EditTaskWindow(EditTaskViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Resources["WindowLoadedAnimation"] is Storyboard sb)
            {
                BeginStoryboard(sb);
            }
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
