using UserTasks.Models.Domain;

namespace UserTasks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Tasks> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Tasks>()
                .HasIndex(p => new { p.CreatedOn, p.Status, p.PeriorityEnum, p.DueDate });

            modelBuilder.Entity<AppUser>().HasMany<Tasks>(e => e.Tasks).WithOne(e => e.CreatedByEmp).HasForeignKey(x => x.CreatedBy);
            //modelBuilder.Entity<AppUser>().HasMany<Tasks>(e => e.Tasks).WithOne(e => e.UpdatedByEmp).HasForeignKey(x => x.UpdatedBy);
            //modelBuilder.Entity<AppUser>().HasMany<Tasks>(e => e.Tasks).WithOne(e => e.DeletedByEmp).HasForeignKey(x => x.DeletedBy);
        }
    }

}
