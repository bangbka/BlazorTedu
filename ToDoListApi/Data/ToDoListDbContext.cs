using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoListApi.Entities;

namespace ToDoListApi.Data
{
    public class ToDoListDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
