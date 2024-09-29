namespace ServiceApp.UI.Client.Features.Tasks;

public class TaskToDoViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Amount { get; set; }
}
