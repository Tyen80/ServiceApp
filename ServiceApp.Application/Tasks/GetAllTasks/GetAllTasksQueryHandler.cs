namespace ServiceApp.Application.Tasks.GetAllTasks;
public class GetAllTasksQueryHandler : IQueryHandler<GetAllTasksQuery, List<TaskToDoResponse>>
{
    private readonly ITaskToDoRepository _taskToDoRepository;

    public GetAllTasksQueryHandler(ITaskToDoRepository taskToDoRepository)
    {
        _taskToDoRepository = taskToDoRepository;
    }

    public async Task<Result<List<TaskToDoResponse>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskToDoRepository.GetAllAsync();
        var result = tasks.Adapt<List<TaskToDoResponse>>();
        return Result.Ok(result);
    }
}
