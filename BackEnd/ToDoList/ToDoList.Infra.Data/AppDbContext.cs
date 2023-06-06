using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoList.Domain.Models;
using ToDoList.Infrastructure.Models;
using ToDoList.Infrastructure.Extensions; 

namespace ToDoList.Infrastructure
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<ToDo> ToDos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(),
                t => t.GetInterfaces().Any(i =>
                            i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) &&
                            typeof(BaseEntity).IsAssignableFrom(i.GenericTypeArguments[0]))
            );
            builder.SeedUsers();
            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var markedAsModified = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            var markedAsAdded = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var item in markedAsModified)
            {
                if (item.Entity is BaseEntity entity)
                {
                    entity.ModifiedAt = DateTime.UtcNow;
                }
            }
            foreach (var item in markedAsAdded)
            {
                if (item.Entity is BaseEntity entity)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}
