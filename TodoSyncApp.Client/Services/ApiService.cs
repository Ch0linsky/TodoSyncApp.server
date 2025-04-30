// -----------------------------------------------
// Archivo: ApiService.cs
// Propósito: Conectar con la API REST del servidor
// -----------------------------------------------

using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoSyncApp.Client.Models;

namespace TodoSyncApp.Client.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:5001/api/") // Cambiar según puerto real
        };
    }


    public async Task<List<TodoTask>> GetTasksAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<TodoTask>>("task") ?? new();
    }

    public async Task AddTaskAsync(TodoTask task)
    {
        await _httpClient.PostAsJsonAsync("task", task);
    }

    public async Task UpdateTaskAsync(TodoTask task)
    {
        await _httpClient.PutAsJsonAsync($"task/{task.Id}", task);
    }

    public async Task DeleteTaskAsync(int id)
    {
        await _httpClient.DeleteAsync($"task/{id}");
    }
}
