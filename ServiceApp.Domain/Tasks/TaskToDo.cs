namespace ServiceApp.Domain.Tasks;
public class TaskToDo
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string FamilyId { get; set; } = string.Empty;
}
