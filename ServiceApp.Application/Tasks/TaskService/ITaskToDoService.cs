using ServiceApp.Application.Tasks.CreateTask;
using ServiceApp.Application.Tasks.UpdateTask;

namespace ServiceApp.Application.Tasks.TaskService;
public interface ITaskToDoService
{
    Task<List<TaskToDoResponse>> GetAllTaskAsync();
    Task<List<TaskToDoResponse>> GetAllTaskByUserId();
    Task<TaskToDoResponse> GetTaskByIdAsync(int id);
    Task<TaskToDoResponse> CreateTaskAsync(CreateTaskCommand command);
    Task<TaskToDoResponse> UpdateTaskAsync(UpdateTaskToDoCommand command);
    Task<bool> DeleteTaskAsync(int id);
}
