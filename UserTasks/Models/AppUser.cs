namespace UserTasks.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; }=null!;
        public string Password { get; set; }=null!;
        public ICollection<Tasks>? Tasks { get; set; }

    }
}
