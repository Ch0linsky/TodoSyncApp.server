using Microsoft.EntityFrameworkCore;
using TodoSyncApp.Server.Data;
using TodoSyncApp.Server.Repositories;
using TodoSyncApp.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

// Configuración del pipeline
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<TaskHub>("/taskhub");
});

app.Run();
