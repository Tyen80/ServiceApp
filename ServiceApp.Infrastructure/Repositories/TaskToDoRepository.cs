using Microsoft.EntityFrameworkCore;
using ServiceApp.Domain.Tasks;

namespace ServiceApp.Infrastructure.Repositories;
public class TaskToDoRepository : ITaskToDoRepository
{
    private readonly ApplicationDbContext _context;

    public TaskToDoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskToDo>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskToDo?> GetByIdAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        return task;
    }

    public async Task<TaskToDo> CreateAsync(TaskToDo task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskToDo?> UpdateAsync(TaskToDo task)
    {
        var taskToUpdate = await GetByIdAsync(task.Id);
        if (taskToUpdate == null)
        {
            return null;
        }
        taskToUpdate.Title = task.Title;
        taskToUpdate.Description = task.Description;
        taskToUpdate.Amount = task.Amount;
        await _context.SaveChangesAsync();
        return taskToUpdate;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var taskToDelete = await GetByIdAsync(id);
        if (taskToDelete == null)
        {
            return false;
        }
        _context.Tasks.Remove(taskToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}
