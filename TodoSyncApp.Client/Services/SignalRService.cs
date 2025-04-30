// -----------------------------------------------
// Archivo: SignalRService.cs
// Propósito: Manejar conexión con el servidor vía SignalR
// -----------------------------------------------

using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client; 
using System;
using System.Threading.Tasks;
using TodoSyncApp.Client.Models;

namespace TodoSyncApp.Client.Services;

public class SignalRService
{
    private Microsoft.AspNet.SignalR.Client.HubConnection _connection;

    public event Action<TodoTask>? TaskAdded;
    public event Action<TodoTask>? TaskUpdated;
    public event Action<int>? TaskDeleted;

    public async Task ConnectAsync()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:5001/taskhub") // Asegúrate que coincide con tu servidor
            .WithAutomaticReconnect()
            .Build();

        _connection.On<TodoTask>("TaskAdded", task => TaskAdded?.Invoke(task));
        _connection.On<TodoTask>("TaskUpdated", task => TaskUpdated?.Invoke(task));
        _connection.On<int>("TaskDeleted", id => TaskDeleted?.Invoke(id));

        await _connection.StartAsync();
    }

    public async Task DisconnectAsync()
    {
        if (_connection != null)
            await _connection.StopAsync();
    }
}
