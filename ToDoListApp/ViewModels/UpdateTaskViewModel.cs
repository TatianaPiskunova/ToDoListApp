using System.ComponentModel.DataAnnotations;

namespace ToDoListApp
{
    public class UpdateTaskViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
        public string IsDone { get; set; }
        public string IsDel { get; set; }
    }
}
