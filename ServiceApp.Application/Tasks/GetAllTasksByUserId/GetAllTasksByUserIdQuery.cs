namespace ServiceApp.Application.Tasks.GetAllTasksByUserId;
public class GetAllTasksByUserIdQuery : IQuery<List<TaskToDoResponse>>
{
    public int UserId { get; set; }
}
