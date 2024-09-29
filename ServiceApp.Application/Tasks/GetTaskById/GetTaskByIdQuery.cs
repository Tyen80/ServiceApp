namespace ServiceApp.Application.Tasks.GetTaskById;
public class GetTaskByIdQuery : IQuery<TaskToDoResponse>
{
    public int Id { get; set; }
}
