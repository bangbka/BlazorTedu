using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Data;

namespace ToDoListApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public readonly ToDoListDbContext _context;
        public TaskRepository(ToDoListDbContext context)
        {
            _context = context;
        }
        public async Task<Entities.Task> Create(Entities.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> Delete(Entities.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<Entities.Task>> GetTaskList()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Entities.Task> Update(Entities.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
