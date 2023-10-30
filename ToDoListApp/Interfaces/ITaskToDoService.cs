namespace ToDoListApp
{
    public interface ITaskToDoService
    {
        void AddNewTask(AddTaskViewModel taskToDo);
        void UpdateTask(UpdateTaskViewModel vm);
        void FinishTask(int id);
        void DeleteById(int id);
        string GetAll();
        TaskToDo FindById(int id);


    }
}
