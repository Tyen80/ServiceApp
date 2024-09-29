using Microsoft.AspNetCore.Mvc;
using ServiceApp.Application.Tasks;
using ServiceApp.Application.Tasks.CreateTask;
using ServiceApp.Application.Tasks.TaskService;

namespace ServiceApp.UI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskToDoService _taskToDoService;

    public TaskController(ITaskToDoService taskToDoService)
    {
        _taskToDoService = taskToDoService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskToDoResponse>>> GetAllTaskAsync()
    {
        var result = await _taskToDoService.GetAllTaskAsync();
        return Ok(result);
    }

    [HttpGet("user")]
    public async Task<ActionResult<List<TaskToDoResponse>>> GetAllTaskByUserId()
    {
        var result = await _taskToDoService.GetAllTaskByUserId();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskToDoResponse>> GetTaskByIdAsync(int id)
    {
        var result = await _taskToDoService.GetTaskByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<TaskToDoResponse>> CreateTaskAsync([FromBody] CreateTaskCommand command)
    {
        var result = await _taskToDoService.CreateTaskAsync(command);
        return Ok(result);
    }

}
