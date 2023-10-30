using System.ComponentModel.DataAnnotations;

namespace ToDoListApp
{ 
    public class TaskToDo
    {
        [Key]
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsDone { get; set; }
        public bool? IsDel { get; set; }
        

    }
}
