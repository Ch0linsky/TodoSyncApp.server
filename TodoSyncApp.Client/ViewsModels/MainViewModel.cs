using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TodoSyncApp.Client.Helpers;
using TodoSyncApp.Client.Models;
using TodoSyncApp.Client.Views;
using TodoSyncApp.Client.ViewsModels;

namespace TodoSyncApp.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new();
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            AddCommand = new RelayCommand(AddTask);
            EditCommand = new RelayCommand<TaskItem>(EditTask);
            DeleteCommand = new RelayCommand<TaskItem>(DeleteTask);
        }

        private void AddTask()
        {
            var newTask = new TaskItem();
            var vm = new EditTaskViewModel(newTask);
            var window = new EditTaskWindow(vm)
            {
                Owner = Application.Current.MainWindow
            };

            if (window.ShowDialog() == true)
            {
                Tasks.Add(newTask);
            }
        }

        private void EditTask(TaskItem task)
        {
            if (task == null) return;

            var vm = new EditTaskViewModel(task);
            var window = new EditTaskWindow(vm)
            {
                Owner = Application.Current.MainWindow
            };

            if (window.ShowDialog() == true)
            {
                // Cambios ya reflejados vía binding
            }
        }

        private void DeleteTask(TaskItem task)
        {
            if (task == null) return;

            var result = MessageBox.Show("¿Deseas eliminar esta tarea?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Tasks.Remove(task);
            }
        }
    }
}
