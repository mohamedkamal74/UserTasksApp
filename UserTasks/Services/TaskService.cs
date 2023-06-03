﻿namespace UserTasks.Services
{
   
    public class TaskService: ITasksService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tasks> Create(Tasks tasks)
        {
            return tasks;
        }

        public Tasks Delete(Tasks tasks)
        {
            _context.Tasks.Remove(tasks);
            _context.SaveChanges();
            return tasks;
        }

        public async Task<IEnumerable<Tasks>> GetAll()
        {
            return await _context.Tasks.Include(u=>u.AppUser).OrderByDescending(m => m.Date).ToListAsync();
        }

        public async Task<Tasks> GetById(int id)
        {
            return await _context.Tasks.Include(u=>u.AppUser).SingleOrDefaultAsync(m => m.Id == id);
        }

        public Tasks Update(Tasks tasks)
        {
            _context.Tasks.Update(tasks);
            _context.SaveChanges();
            return tasks;
        }
    }
}
