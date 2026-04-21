using TaskBlog.Domain.Entities;

namespace TaskBlog.Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllTasksAsync(int pageNumber, int pageSize, string? searchTerm);
    Task<TaskItem?> GetTaskItemAsync(Guid id);
    Task<TaskItem> CreateTaskAsync(TaskItem task);
    Task UpdateTaskAsync(TaskItem task);
    Task DeleteTaskAsync(Guid id);
}
