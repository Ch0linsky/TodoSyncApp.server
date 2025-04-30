using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TodoSyncApp.Client.Services
{
    public class TaskLockService
    {
        private readonly HttpClient _httpClient;

        public TaskLockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> LockTaskAsync(int taskId, string username)
        {
            var content = new StringContent(JsonSerializer.Serialize(username), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/todotasks/lock/{taskId}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task UnlockTaskAsync(int taskId)
        {
            await _httpClient.PostAsync($"/api/todotasks/unlock/{taskId}", null);
        }
    }
}
