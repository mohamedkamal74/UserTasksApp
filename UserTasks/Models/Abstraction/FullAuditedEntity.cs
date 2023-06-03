using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserTasks.Models.Domain;

namespace UserTasks.Models.Abstraction;

public abstract class FullAuditedEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }


    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int? CreatedBy { get; set; }
    [ForeignKey("CreatedBy")]
    public virtual AppUser CreatedByEmp { get; set; }

    //public DateTime? UpdatedOn { get; set; }
    //public int UpdatedBy { get; set; }
    //[ForeignKey("UpdatedBy")]
    //public virtual AppUser UpdatedByEmp { get; set; }

}
