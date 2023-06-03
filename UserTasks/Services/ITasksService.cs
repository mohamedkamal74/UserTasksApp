using UserTasks.Models.Domain;

namespace UserTasks.Services
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks>> GetAll();
        Task<Tasks> GetById(int id);
        Task<Tasks> Create(Tasks tasks);
        Tasks Update(Tasks tasks);
        Tasks Delete(Tasks tasks);
    }
}
