
namespace ServiceApp.Application.Tasks.GetTaskById;
public class GetTaskByIdQueryHandler : IQueryHandler<GetTaskByIdQuery, TaskToDoResponse>
{
    private readonly ITaskToDoRepository _taskToDoRepository;

    public GetTaskByIdQueryHandler(ITaskToDoRepository taskToDoRepository)
    {
        _taskToDoRepository = taskToDoRepository;
    }

    public async Task<Result<TaskToDoResponse>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskToDoRepository.GetByIdAsync(request.Id);
        if (task != null)
        {
            return task.Adapt<TaskToDoResponse>();
        }
        else
        {
            return Result.Fail<TaskToDoResponse>("Task not found");
        }
    }
}
