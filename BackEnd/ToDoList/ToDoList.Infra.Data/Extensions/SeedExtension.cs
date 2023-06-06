using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.Models;

namespace ToDoList.Infrastructure.Extensions
{
    public static class SeedExtension
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "SuperAdmin", NormalizedName = "SUPERADMIN".ToUpper() });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<User>();


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1, // primary key
                    UserName = "SuperAdmin",
                    NormalizedUserName = "SUPERADMIN",
                    PasswordHash = hasher.HashPassword(null, "SuperAdmin007!")
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 1,
                    UserId = 1
                }
            );
        }
    }
}
