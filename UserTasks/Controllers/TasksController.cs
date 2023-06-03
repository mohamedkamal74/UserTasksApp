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
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _tasksService.GetAll();
            return Ok(tasks);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var task = await _tasksService.GetById(id);
            if (task == null)
                return NotFound($"No Task with this Id: {id}");
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromForm] TasksDto dto)
        {
            var task = new Tasks
            {
                Name = dto.Name,
                Description = dto.Description,
                Date =dto.Date,
                UserId = dto.UserId,
                Status = dto.Status
                
            };
            await _tasksService.Create(task);
            return Ok(task);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromForm] TasksDto dto)
        {
            var task =await _tasksService.GetById(id);
            if(task == null)
                return NotFound($"No task found with Id: {id}");

            task.Name = dto.Name;
            task.Description = dto.Description;
            task.Date = DateTime.Now;
            task.Status = dto.Status;

            _tasksService.Update(task);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _tasksService.GetById(id);
            if (task == null)
                return NotFound($"No task found with Id: {id}");
            _tasksService.Delete(task);
            return Ok(task);

        }
    }
}