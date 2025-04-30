// -----------------------------------------------------
// Archivo: TodoTask.cs
// Propósito: Modelo de entidad para representar una tarea
// Proyecto: TodoSyncApp.Server
// -----------------------------------------------------

namespace TodoSyncApp.Server.Models;

public class TodoTask
{
    public int Id { get; set; }

    // Título de la tarea
    public string Title { get; set; } = "";

    // Estado de completado
    public bool IsCompleted { get; set; }

    // Bloqueo para edición simultánea
    public bool IsLocked { get; set; }
    public string? LockedBy { get; set; }
    public DateTime? LockedAt { get; set; }

    // Nivel de prioridad de la tarea (Alta, Media, Baja)
    public string? Priority { get; set; } = "Media";

    // Etiquetas asignadas (separadas por coma)
    public string? Tags { get; set; }

    //  Fecha límite para completar la tarea
    public DateTime? DueDate { get; set; }
}
