namespace UserTasks.Services
{
    public class TaskService : ITasksService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ObjectSourceResponse<bool>> Create(TasksDto dto)
        {
            try
            {
                Tasks tasks = new Tasks(dto.Name, dto.Description, Convert.ToDateTime(dto.CreationTime),
                (PeriorityEnum)dto.Periority, dto.Status);
                _context.Tasks.Add(tasks);
                await _context.SaveChangesAsync();
                return new ObjectSourceResponse<bool>(true, "Task Created Successfully");
            }
            catch (Exception ex)
            {
                return new ObjectSourceResponse<bool>(false, ex.Message);
            }
        }

        public async Task<ObjectSourceResponse<bool>> Delete(int id)
        {
            Tasks tasks = await _context.Tasks.FirstAsync(x => x.Id == id);
            if (tasks is null)
                return new ObjectSourceResponse<bool>(false, "Task Not Found");

            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();
            return new ObjectSourceResponse<bool>(true, "Task Removed Successfully");
        }

        public async Task<ObjectSourceResponse<IEnumerable<TasksDto>>> GetAll()
        {
            var result = await _context.Tasks.Include(u => u.CreatedByEmp).AsNoTracking().OrderByDescending(m => m.DueDate)
              .Select(c => new TasksDto
              {
                  Date = c.DueDate,
                  Description = c.Description,
                  Name = c.TaskName,
                  Periority = (int)c.PeriorityEnum,
                  Status = c.Status,
                  TaskId = c.Id,
                  UserId = c.CreatedBy.Value,
                  CreationTime = c.CreatedOn.ToString("dd-MM-yyyy")
              }).ToListAsync();
            return new ObjectSourceResponse<IEnumerable<TasksDto>>(result, null);
        }

        public async Task<ObjectSourceResponse<TasksDto>> GetById(int id)
        {
            var task = await _context.Tasks.Include(u => u.CreatedByEmp).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (task is null)
                return new ObjectSourceResponse<TasksDto>(null, "Task Not Found");

            return new ObjectSourceResponse<TasksDto>(new TasksDto()
            {
                Date = task.DueDate,
                Description = task.Description,
                Name = task.TaskName,
                Periority = (int)task.PeriorityEnum,
                Status = task.Status,
                TaskId = task.Id,
                UserId = task.CreatedBy.Value,
                CreationTime = task.CreatedOn.ToString("dd-MM-yyyy")
            }, null);
        }

        public async Task<ObjectSourceResponse<bool>> Update(TasksDto dto)
        {
            try
            {
                Tasks tasks = await _context.Tasks.FirstAsync(x => x.Id == dto.TaskId);
                if (tasks is null)
                    return new ObjectSourceResponse<bool>(false, "Task Not Found");

                tasks.UpdateTask(dto);
                await _context.SaveChangesAsync();
                return new ObjectSourceResponse<bool>(true, "Task Updated Successfully");

            }
            catch (Exception ex)
            {
                return new ObjectSourceResponse<bool>(false, ex.Message);
            }
        }
    }
}

