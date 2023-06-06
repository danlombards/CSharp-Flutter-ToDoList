namespace ToDoList.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IToDoRepository ToDos { get; }
        void Save();
    }
}
