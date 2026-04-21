using TaskBlog.Domain.Entities;

namespace TaskBlog.Application.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllTasksAsync(int pageNumber, int pageSize, string? searchTerm);
    Task<TaskItem?> GetTaskByIdAsync(Guid id);
    Task AddTaskAsync(TaskItem task);
    Task UpdateTaskAsync(TaskItem task);
    Task DeleteTaskAsync(Guid id);
}
