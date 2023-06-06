namespace ToDoList.Domain.Models
{
    public class ToDo : BaseEntity
    {
        public bool IsDone { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
