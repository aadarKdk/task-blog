using TaskBlog.Application.DTOs;
using TaskBlog.Application.Interfaces;
using TaskBlog.Domain.Entities;

namespace TaskBlog.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm
    )
    {
        var tasks = await _taskRepository.GetAllTasksAsync(pageNumber, pageSize, searchTerm);

        return tasks.Select(t => new TaskResponseDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            Status = t.Status,
            CreatedAt = t.CreatedAt,
        });
    }

    public async Task<TaskResponseDto?> GetTaskByIdAsync(Guid id)
    {
        var task = await _taskRepository.GetTaskByIdAsync(id);

        if (task == null)
            return null;

        return new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            CreatedAt = task.CreatedAt,
        };
    }

    public async Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description ?? string.Empty,
            Status = dto.Status,
            CreatedAt = DateTime.UtcNow,
        };

        await _taskRepository.AddTaskAsync(task);

        return new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            CreatedAt = task.CreatedAt,
        };
    }

    public async Task UpdateTaskAsync(Guid id, UpdateTaskDto dto)
    {
        var existing = await _taskRepository.GetTaskByIdAsync(id);

        if (existing == null)
            throw new KeyNotFoundException("Task not found");

        existing.Title = dto.Title;
        existing.Description = dto.Description ?? string.Empty;
        existing.Status = dto.Status;

        await _taskRepository.UpdateTaskAsync(existing);
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        var existing = await _taskRepository.GetTaskByIdAsync(id);

        if (existing == null)
            throw new KeyNotFoundException("Task not found");

        await _taskRepository.DeleteTaskAsync(existing);
    }
}
