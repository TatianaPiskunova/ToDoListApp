using System.ComponentModel.DataAnnotations;

namespace ToDoListApp
{
    public class AddTaskViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
     
    }
}
