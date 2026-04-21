using Microsoft.EntityFrameworkCore;
using TaskBlog.Application.Interfaces;
using TaskBlog.Infrastructure.Data;

namespace TaskBlog.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasksAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm
    )
    {
        var query = _context.Tasks.AsQueryable();

        if (!String.IsNullOrEmpty(searchTerm))
            query = query.Where(t => t.Title.Contains(searchTerm));

        return await query
            .OrderByDescending(t => t.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<TaskItem?> GetTaskByIdAsync(Guid id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task AddTaskAsync(TaskItem task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(TaskItem task)
    {
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}
