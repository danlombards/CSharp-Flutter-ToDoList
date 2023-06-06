using System.Linq.Expressions;

namespace ToDoList.Infrastructure.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        T? FindById(object id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SoftDelete(T entity);
    }
}
