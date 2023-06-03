using System.ComponentModel.DataAnnotations;
using UserTasks.Models.Abstraction;
using UserTasks.Models.Enums;

namespace UserTasks.Models.Domain;

public class Tasks : FullAuditedEntity
{
    public Tasks(string taskName, string description, DateTime dueDate, PeriorityEnum periorityEnum, string status)
    {
        TaskName = taskName;
        Description = description;
        DueDate = dueDate;
        PeriorityEnum = periorityEnum;
        Status = status;
    }

    [Required, MaxLength(500)]
    public string TaskName { get; private set; }

    [MaxLength(4000)]
    public string Description { get; private set; }

    [Required]
    public DateTime DueDate { get; private set; }

    [Required]
    public PeriorityEnum PeriorityEnum { get; private set; }

    [Required, MaxLength(4000)]
    public string Status { get; private set; }
}