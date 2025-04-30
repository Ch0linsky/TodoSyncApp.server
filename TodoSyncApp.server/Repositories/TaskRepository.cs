// -----------------------------------------------------
// Archivo: TaskRepository.cs
// Propósito: Implementación de acceso a datos para tareas
// Proyecto: TodoSyncApp.Server
// -----------------------------------------------------

using Microsoft.EntityFrameworkCore;
using TodoSyncApp.Server.Data;
using TodoSyncApp.Server.Models;

namespace TodoSyncApp.Server.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoTask>> GetAll() =>
        await _context.Tasks.ToListAsync();

    public async Task<TodoTask?> GetById(int id) =>
        await _context.Tasks.FindAsync(id);

    public async Task Add(TodoTask task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TodoTask task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
