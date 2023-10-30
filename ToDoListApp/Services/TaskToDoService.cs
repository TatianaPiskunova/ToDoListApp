using Newtonsoft.Json;

using ToDoListApp.EF;



namespace ToDoListApp
{
    public class TaskToDoService:ITaskToDoService
    {
        private readonly ApplicationContext db;
        public TaskToDoService(ApplicationContext db) 
        {
            this.db = db;
        }
       public void AddNewTask(AddTaskViewModel taskToDo)
        {
     
           var tmpNewTask = new TaskToDo()
                {
                    Title = taskToDo.Title,
                    Description = taskToDo.Description,
                    DueDate = taskToDo.DueDate,
                    IsDone = false,
                    IsDel = false
                };

                db.Tasks.Add(tmpNewTask);
                db.SaveChanges();

        }
       public void UpdateTask(UpdateTaskViewModel vm)
        {
            var tmp = FindById(vm.Id);
            tmp.Title = vm.Title;
            tmp.Description = vm.Description;
            if(vm.DueDate is not null) { tmp.DueDate = vm.DueDate; }
            if (vm.IsDone == "yes")
            {
                tmp.IsDone= true;
            }
            if (vm.IsDone == "no")
            {
                tmp.IsDone = false;
            }
         
            if (vm.IsDel == "yes")
            {
                tmp.IsDel = true;
            }
            if (vm.IsDel == "no")
            {
                tmp.IsDel = false;
            }
            db.SaveChanges();
        }
       public void FinishTask(int id)
        {
            var tmp = FindById(id);
            tmp.IsDone = true;
            db.SaveChanges();
        }
       public void DeleteById(int id)
        {
            var tmp = FindById(id);
            tmp.IsDel = true;
            db.SaveChanges();



        }

        public string GetAll()
        {
            return JsonConvert.SerializeObject(db.Tasks);
        }

        public TaskToDo FindById(int id) 
        {
             return db.Tasks.FirstOrDefault(x => x.TaskId == id);

        }
    }
}
