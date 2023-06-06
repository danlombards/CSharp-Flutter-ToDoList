
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoList.Domain.Models;
using ToDoList.Infrastructure.Interfaces;

namespace ToDoList.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private AppDbContext dbContext { get; set; }

        public BaseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual IQueryable<T> FindAll()
        {
            return this.dbContext.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.dbContext.Set<T>()
                .Where(expression).AsNoTracking();
        }

        public virtual void Create(T entity)
        {
            this.dbContext.Set<T>().AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            this.dbContext.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public virtual void SoftDelete(T entity)
        {
            var tmpEntity = entity as BaseEntity;
            if (tmpEntity != null)
            {
                tmpEntity.DeletedAt = DateTime.Now;
                this.dbContext.Update(tmpEntity);
            }
        }

        public virtual T? FindById(object id)
        {
            return this.dbContext.Set<T>().Find(id);
        }
    }
}
