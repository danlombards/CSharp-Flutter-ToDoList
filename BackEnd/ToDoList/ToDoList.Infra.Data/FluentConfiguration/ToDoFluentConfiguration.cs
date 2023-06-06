using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.FluentConfiguration
{
    public class ToDoFluentConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.Property(t => t.Title).HasMaxLength(256).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(1024);
        }
    }
}
