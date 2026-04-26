using TaskBlog.Application.DTOs;

namespace TaskBlog.Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm
    );

    Task<TaskResponseDto?> GetTaskByIdAsync(Guid id);

    Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto dto);

    Task UpdateTaskAsync(Guid id, UpdateTaskDto dto);

    Task DeleteTaskAsync(Guid id);
}
