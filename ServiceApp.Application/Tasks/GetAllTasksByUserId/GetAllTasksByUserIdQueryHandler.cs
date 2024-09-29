
namespace ServiceApp.Application.Tasks.GetAllTasksByUserId;
public class GetAllTasksByUserIdQueryHandler : IQueryHandler<GetAllTasksByUserIdQuery, List<TaskToDoResponse>>
{
    private readonly ITaskToDoRepository _taskToDoRepository;
    private readonly IUserService _userService;

    public GetAllTasksByUserIdQueryHandler(ITaskToDoRepository taskToDoRepository, IUserService userService)
    {
        _taskToDoRepository = taskToDoRepository;
        _userService = userService;
    }

    public async Task<Result<List<TaskToDoResponse>>> Handle(GetAllTasksByUserIdQuery request, CancellationToken cancellationToken)
    {
        var userId = await _userService.GetCurrentUserByIdAsync();
        var tasks = await _taskToDoRepository.GetAllAsync();

        var userTasks = tasks.Where(x => x.UserId == userId).ToList();
        var result = userTasks.Adapt<List<TaskToDoResponse>>();
        return result;
    }
}
