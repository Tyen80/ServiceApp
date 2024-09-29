
using Mapster;
using ServiceApp.Domain.Tasks;

namespace ServiceApp.Application.Tasks.CreateTask;
public class CreateTaskCommandHandler : ICommandHandler<CreateTaskCommand, TaskToDoResponse>
{
    private readonly ITaskToDoRepository _taskToDoRepository;
    private readonly IUserService _userService;

    public CreateTaskCommandHandler(ITaskToDoRepository taskToDoRepository, IUserService userService)
    {
        _taskToDoRepository = taskToDoRepository;
        _userService = userService;
    }

    public async Task<Result<TaskToDoResponse>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var userId = await _userService.GetCurrentUserByIdAsync();
        request.UserId = userId;

        var familyId = await _userService.GetCurrentUserByFamilyIdAsync();
        request.FamilyId = familyId;

        try
        {
            var newTask = request.Adapt<TaskToDo>();
            var createdTask = await _taskToDoRepository.CreateAsync(newTask);
            return createdTask.Adapt<TaskToDoResponse>();
        }
        catch (Exception)
        {
            return Result<TaskToDoResponse>.Fail<TaskToDoResponse>("Task not created");
        }
    }
}
