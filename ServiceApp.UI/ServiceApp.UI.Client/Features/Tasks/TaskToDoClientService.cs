using ServiceApp.Application.Tasks;
using ServiceApp.Application.Tasks.CreateTask;
using ServiceApp.Application.Tasks.TaskService;
using ServiceApp.Application.Tasks.UpdateTask;
using System.Net.Http.Json;

namespace ServiceApp.UI.Client.Features.Tasks;

public class TaskToDoClientService : ITaskToDoService
{
    private readonly HttpClient _http;

    public TaskToDoClientService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TaskToDoResponse>> GetAllTaskAsync()
    {
        var response = await _http.GetFromJsonAsync<List<TaskToDoResponse>>("api/task");
        return response ?? new List<TaskToDoResponse>();
    }
    public async Task<List<TaskToDoResponse>> GetAllTaskByUserId()
    {
        var response = await _http.GetFromJsonAsync<List<TaskToDoResponse>>("api/task/user");
        return response ?? new List<TaskToDoResponse>();
    }

    public async Task<TaskToDoResponse> GetTaskByIdAsync(int id)
    {
        var response = await _http.GetFromJsonAsync<TaskToDoResponse>($"api/task/{id}");
        return response ?? new TaskToDoResponse();
    }

    public async Task<TaskToDoResponse> CreateTaskAsync(CreateTaskCommand command)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/task", command);
            if (response.IsSuccessStatusCode)
            {
                var taskResponse = await response.Content.ReadFromJsonAsync<TaskToDoResponse>();
                if (taskResponse != null)
                    return taskResponse;
                else
                    throw new Exception("Failed to create task");
            }
            else
            {
                // Handle error response
                throw new Exception("Failed to create task");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to create task", ex);
        }
    }
    public async Task<TaskToDoResponse> UpdateTaskAsync(UpdateTaskToDoCommand command)
    {
        var result = await _http.PutAsJsonAsync($"api/task/{command.Id}", command);
        if (result.IsSuccessStatusCode)
        {
            var taskResponse = await result.Content.ReadFromJsonAsync<TaskToDoResponse>();
            if (taskResponse != null)
                return taskResponse;
            else
                throw new Exception("Failed to update task");
        }
        else
        {
            // Handle error response
            throw new Exception("Failed to update task");
        }
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var result = await _http.DeleteAsync($"api/task/{id}");
        return result.IsSuccessStatusCode;
    }


}
