using UserTasks.Models.Abstraction;

namespace UserTasks.Models.Domain
{
    public class AppUser : FullAuditedEntity
    {
        public AppUser(string fullName, string email, string userName, string password)
        {
            FullName = fullName;
            Email = email;
            UserName = userName;
            Password = password;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        private List<Tasks> _tasks = new List<Tasks>();
        public IReadOnlyList<Tasks> Tasks => _tasks;
    }
}
