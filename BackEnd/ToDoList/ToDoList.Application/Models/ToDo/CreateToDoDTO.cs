using System.ComponentModel.DataAnnotations;

namespace ToDoList.Application.Models.ToDo
{
    public class CreateToDoDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
