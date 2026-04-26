using System.ComponentModel.DataAnnotations;
using TaskBlog.Domain.Enums;

namespace TaskBlog.Application.DTOs;

public class UpdateTaskDto
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public TaskBlog.Domain.Enums.TaskStatus Status { get; set; }
}
