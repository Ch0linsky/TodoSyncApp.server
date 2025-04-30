// -----------------------------------------------
// Archivo: TodoTask.cs
// Propósito: Representa una tarea en el cliente WPF
// -----------------------------------------------

namespace TodoSyncApp.Client.Models;

public class TodoTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public string Priority { get; set; }
    public string Tags { get; set; }
    public DateTime? DueDate { get; set; }
}
