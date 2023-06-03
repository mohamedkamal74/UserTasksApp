namespace UserTasks.Dtos
{
    public class TasksDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
    }
}
