namespace ToDoList.Application.Models
{
    public class BaseEntityDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
