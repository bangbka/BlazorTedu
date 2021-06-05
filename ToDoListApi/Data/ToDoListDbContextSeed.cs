using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Enums;

namespace ToDoListApi.Data
{
    public class ToDoListDbContextSeed
    {
        private readonly IPasswordHasher<Entities.User> _passwordHasher = new PasswordHasher<Entities.User>();
        public async Task SeedAsync(ToDoListDbContext context, ILogger<ToDoListDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new Entities.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    PhoneNumber = "032132131",
                    UserName = "admin"
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123$");
                context.Users.Add(user);
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entities.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same tasks 1",
                    CreatedDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.ToDo
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
