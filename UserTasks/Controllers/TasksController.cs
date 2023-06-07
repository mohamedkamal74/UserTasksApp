using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserTasks.Services;

namespace UserTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks(string status, int periority, DateTime? dueDate)
        {
            var tasks = await _tasksService.GetAll();
            return Ok(tasks);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var task = await _tasksService.GetById(id);
            return Ok(task);
        }

        [HttpPost(nameof(AddTask))]
        public async Task<IActionResult> AddTask(TasksDto dto)
        {
            var task = await _tasksService.Create(dto);
            return Ok(task);
        }

        [HttpPost(nameof(UpdateTask))]
        public async Task<IActionResult> UpdateTask(TasksDto dto)
        {
            var task = await _tasksService.Update(dto);
            return Ok(task);
        }

        [HttpPost("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _tasksService.Delete(id);
            return Ok(task);

        }
    }
}