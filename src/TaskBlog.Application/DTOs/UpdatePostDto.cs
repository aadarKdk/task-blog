using System.ComponentModel.DataAnnotations;

namespace TaskBlog.Application.DTOs;

public class UpdatePostDto
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    public bool IsPublished { get; set; }
}
