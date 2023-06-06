using Microsoft.AspNetCore.Identity;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Models
{
    public class User : IdentityUser<int>
    {
        public virtual ICollection<ToDo>? Todos { get; set; }
    }
}
