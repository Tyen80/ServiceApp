using ServiceApp.Domain.Tasks;

namespace ServiceApp.Domain.ToDoItems;
public class ToDoItem
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public bool IsComplete { get; set; } = false;
    public bool IsApproved { get; set; } = false;
    public DateTime DueDate { get; set; } = DateTime.Now;
    public string UserId { get; set; } = string.Empty;
    public string FamilyId { get; set; } = string.Empty;

    public TaskToDo? Task { get; set; }
}
