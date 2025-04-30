using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoSyncApp.Client.Models;

namespace TodoSyncApp.Client.Services;

public class TaskService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl = "https://localhost:5001"; // Ajusta si es diferente

    public TaskService()
    {
        _http = new HttpClient();
    }

    public async Task<List<TodoTask>> GetTasksAsync()
    {
        return await _http.GetFromJsonAsync<List<TodoTask>>($"{_baseUrl}/api/task");
    }

    public async Task AddTaskAsync(TodoTask task)
    {
        var response = await _http.PostAsJsonAsync($"{_baseUrl}/api/task", task);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateTaskAsync(TodoTask task)  
    {
        var response = await _http.PutAsJsonAsync($"{_baseUrl}/api/task/{task.Id}", task);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteTaskAsync(int id)
    {
        var response = await _http.DeleteAsync($"{_baseUrl}/api/task/{id}");
        response.EnsureSuccessStatusCode();
    }
}
