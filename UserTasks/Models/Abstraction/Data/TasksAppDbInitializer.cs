using UserTasks.Models.Domain;

namespace UserTasks.Data;

public class TasksAppDbInitializer
{
    private static ApplicationDbContext context;
    public static void Initialize(IServiceProvider serviceProvider)
    {
        context = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));

        InitializeSchedules();
    }

    private static void InitializeSchedules()
    {
        if (!context.AppUsers.Any())
        {
            AppUser userOne = new("Mohamed Kamal", "moKamal@gmail.com", "Mo_Kamal", "P@ssw0rd");
            AppUser userTwo = new("Ahmed Shafik", "ahmedshafik@gmail.com", "Ahmed_shafik", "P@ssw0rd");

            context.AppUsers.Add(userOne);
            context.AppUsers.Add(userTwo);

            context.SaveChanges();
        }
    }
}
