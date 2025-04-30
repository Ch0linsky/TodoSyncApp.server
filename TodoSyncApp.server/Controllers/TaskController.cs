// -----------------------------------------------
// Archivo: TaskController.cs
// Propósito: Provee endpoints CRUD y emite eventos SignalR
// -----------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TodoSyncApp.Server.Data;
using TodoSyncApp.Server.Hubs;
using TodoSyncApp.Server.Models;
using TodoSyncApp.Server.Services;

namespace TodoSyncApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TaskService _taskService;
    private readonly IHubContext<TaskHub> _hub;


    public TasksController()
    {
        _taskService = new TaskService(new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()));
    }
    public TaskController(AppDbContext context, IHubContext<TaskHub> hub)
    {
        _context = context;
        _hub = hub;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoTask>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<TodoTask>> AddTask(TodoTask task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        await _hub.Clients.All.SendAsync("TaskAdded", task);

        return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, TodoTask task)
    {
        if (id != task.Id)
            return BadRequest();

        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        await _hub.Clients.All.SendAsync("TaskUpdated", task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
            return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        await _hub.Clients.All.SendAsync("TaskDeleted", id);
        return NoContent();
    }

    [HttpPost("lock/{id}")]
    public async Task<IActionResult> LockTask(int id, [FromBody] string username)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return NotFound();

        if (task.IsLocked) return BadRequest("La tarea ya está bloqueada.");

        task.IsLocked = true;
        task.LockedBy = username;
        task.LockedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        await _hub.Clients.All.SendAsync("TaskUpdated", task);
        return Ok(task);
    }

    [HttpPost("unlock/{id}")]
public async Task<IActionResult> UnlockTask(int id)
{
    var task = await _context.Tasks.FindAsync(id);
    if (task == null) return NotFound();

    task.IsLocked = false;
    task.LockedBy = null;
    task.LockedAt = null;

    await _context.SaveChangesAsync();
    await _hub.Clients.All.SendAsync("TaskUpdated", task);
    return Ok(task);
}


}
