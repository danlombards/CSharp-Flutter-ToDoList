namespace ToDoList.Domain.Models
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
