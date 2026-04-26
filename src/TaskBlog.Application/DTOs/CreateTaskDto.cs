using System.ComponentModel.DataAnnotations;

namespace TaskBlog.Application.DTOs;

public class CreateTaskDto
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }
    public TaskBlog.Domain.Enums.TaskStatus Status { get; set; }
}
