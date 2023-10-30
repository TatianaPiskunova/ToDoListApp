namespace ToDoListApp.EF
{
    public class DbInitializer
    {

        public static async Task InitializeAsync(ApplicationContext context)
        {

            if (!context.Tasks.Any())
            {
                var tasks = new TaskToDo[] {
                    new TaskToDo
                    {
                       
                        Title =" задача 1",
                        Description="Описание к задаче 1",
                        DueDate = new DateTime(2024, 1, 20),
                        IsDone=false,
                        IsDel=false
                    },
                    new TaskToDo
                    {

                        Title =" задача 2",
                        Description="Описание к задаче 2",
                        DueDate = new DateTime(2024, 5, 5),
                        IsDone=true,
                        IsDel=false
                    },

                };
                context.Tasks.AddRange(tasks);
                context.SaveChangesAsync();
            }





        }
    }
}