namespace UserTasks.Services
{
    public interface ITasksService
    {
        Task<ObjectSourceResponse<IEnumerable<TasksDto>>> GetAll();
        Task<ObjectSourceResponse<TasksDto>> GetById(int id);
        Task<ObjectSourceResponse<bool>> Create(TasksDto dto);
        Task<ObjectSourceResponse<bool>> Update(TasksDto dto);
        Task<ObjectSourceResponse<bool>> Delete(int id);
    }
}
