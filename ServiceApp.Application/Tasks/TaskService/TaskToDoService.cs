using ServiceApp.Application.Tasks.CreateTask;
using ServiceApp.Application.Tasks.DeleteTask;
using ServiceApp.Application.Tasks.GetAllTasks;
using ServiceApp.Application.Tasks.GetAllTasksByUserId;
using ServiceApp.Application.Tasks.GetTaskById;
using ServiceApp.Application.Tasks.UpdateTask;

namespace ServiceApp.Application.Tasks.TaskService;
public class TaskToDoService : ITaskToDoService
{
    private readonly ISender _sender;

    public TaskToDoService(ISender sender)
    {
        _sender = sender;
    }

    public async Task<List<TaskToDoResponse>> GetAllTaskAsync()
    {
        var result = await _sender.Send(new GetAllTasksQuery());
        return result?.Value ?? new List<TaskToDoResponse>();
    }

    public async Task<List<TaskToDoResponse>> GetAllTaskByUserId()
    {
        var result = await _sender.Send(new GetAllTasksByUserIdQuery());
        return result?.Value ?? new List<TaskToDoResponse>();
    }

    public async Task<TaskToDoResponse> GetTaskByIdAsync(int id)
    {
        var result = await _sender.Send(new GetTaskByIdQuery { Id = id });
        return result?.Value ?? new TaskToDoResponse();
    }

    public async Task<TaskToDoResponse> CreateTaskAsync(CreateTaskCommand command)
    {
        var result = await _sender.Send(command);
        return result?.Value ?? new TaskToDoResponse();
    }

    public async Task<TaskToDoResponse> UpdateTaskAsync(UpdateTaskToDoCommand command)
    {
        var result = await _sender.Send(command);
        return result?.Value ?? new TaskToDoResponse();
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var result = await _sender.Send(new DeleteTaskToDoCommand { Id = id });
        return result.Success;
    }
}
