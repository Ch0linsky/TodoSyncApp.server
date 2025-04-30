// -----------------------------------------------------
// Archivo: AppDbContext.cs
// Propósito: Contexto de Entity Framework para acceso a base de datos
// Proyecto: TodoSyncApp.Server
// -----------------------------------------------------

using Microsoft.EntityFrameworkCore;
using TodoSyncApp.Server.Models;

namespace TodoSyncApp.Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TodoTask> Tasks => Set<TodoTask>();

    public object TodoTasks { get; internal set; }
}
