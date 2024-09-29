namespace ServiceApp.Application.Tasks.UpdateTask;
public class UpdateTaskToDoCommandHandler : ICommandHandler<UpdateTaskToDoCommand, TaskToDoResponse?>
{
    private readonly ITaskToDoRepository _taskToDoRepository;

    public UpdateTaskToDoCommandHandler(ITaskToDoRepository taskToDoRepository)
    {
        _taskToDoRepository = taskToDoRepository;
    }

    async Task<Result<TaskToDoResponse?>> IRequestHandler<UpdateTaskToDoCommand, Result<TaskToDoResponse?>>.Handle(UpdateTaskToDoCommand request, CancellationToken cancellationToken)
    {
        var updatedTask = request.Adapt<TaskToDo>();
        var task = await _taskToDoRepository.UpdateAsync(updatedTask);
        if (task != null)
        {
            return task.Adapt<TaskToDoResponse>();
        }
        else
        {
            return Result.Fail<TaskToDoResponse?>("Task not updated");
        }
    }
}
