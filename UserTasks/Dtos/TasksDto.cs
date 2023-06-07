namespace UserTasks.Dtos
{
    public class TasksDto
    {
        public int TaskId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int Periority { get; set; }
        public string CreationTime { get; set; }
        public string PeriorityName { get; set; }
        public string DueDateString { get; set; }

    }
}
