using ToDoList.Infrastructure.Interfaces;
using ToDoList.Infrastructure.Repositories;

namespace ToDoList.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private IToDoRepository _todos;
        public IToDoRepository ToDos
        {
            get
            {
                if (_todos == null)
                {
                    _todos = new ToDoRepository(_dbContext);
                }
                return _todos;
            }
        }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
