namespace ServiceApp.Application.Tasks.DeleteTask;
public class DeleteTaskToDoCommandHandler : ICommandHandler<DeleteTaskToDoCommand>
{
    private readonly ITaskToDoRepository _taskToDoRepository;

    public DeleteTaskToDoCommandHandler(ITaskToDoRepository taskToDoRepository)
    {
        _taskToDoRepository = taskToDoRepository;
    }

    public async Task<Result> Handle(DeleteTaskToDoCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _taskToDoRepository.DeleteAsync(request.Id);
        return deleted ? Result.Ok() : Result.Fail("Task not deleted");
    }
}
