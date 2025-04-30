// -----------------------------------------------------
// Archivo: ITaskRepository.cs
// Propósito: Contrato para operaciones CRUD de tareas
// Proyecto: TodoSyncApp.Server
// -----------------------------------------------------

using TodoSyncApp.Server.Models;

namespace TodoSyncApp.Server.Repositories;

public interface ITaskRepository
{
    Task<List<TodoTask>> GetAll();
    Task<TodoTask?> GetById(int id);
    Task Add(TodoTask task);
    Task Update(TodoTask task);
    Task Delete(int id);
}

