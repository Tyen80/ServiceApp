using Microsoft.AspNetCore.Identity;
using ServiceApp.Domain.Tasks;
using ServiceApp.Domain.ToDoItems;
using ServiceApp.Domain.Users;

namespace ServiceApp.Infrastructure.Authentication;
public class User : IdentityUser, IUser
{
    public List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    public List<TaskToDo> TaskToDos { get; set; } = new List<TaskToDo>();
}
