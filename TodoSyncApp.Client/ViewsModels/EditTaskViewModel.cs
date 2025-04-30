using System;
using System.Windows.Input;
using TodoSyncApp.Client.Models;
using TodoSyncApp.Client.ViewsModels;

namespace TodoSyncApp.Client.ViewModels
{
    public class EditTaskViewModel : ViewModelBase
    {
        public TaskItem Task { get; }

        public ICommand SaveCommand { get; }

        public event EventHandler SaveSucceeded;

        public EditTaskViewModel(TaskItem task)
        {
            Task = task;
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Task.Title))
            {
                System.Windows.MessageBox.Show("El título no puede estar vacío.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Task.Priority))
            {
                System.Windows.MessageBox.Show("Selecciona una prioridad.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                return;
            }

            SaveSucceeded?.Invoke(this, EventArgs.Empty);
        }
    }
}
