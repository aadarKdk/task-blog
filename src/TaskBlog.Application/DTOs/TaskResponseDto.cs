using TaskBlog.Domain.Enums;

namespace TaskBlog.Application.DTOs;

public class TaskResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskBlog.Domain.Enums.TaskStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
