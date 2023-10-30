using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.EF
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {


        }
        public DbSet<TaskToDo> Tasks { get; set; }
     


    }
}
