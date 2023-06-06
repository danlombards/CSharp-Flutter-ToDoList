using ToDoList.Domain.Models;
using ToDoList.Infrastructure.Interfaces;

namespace ToDoList.Infrastructure.Repositories
{
    public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(AppDbContext appDbContext) : base(appDbContext) { }

    }
}
