using TaskBlog.Domain.Entities;
using TaskBlog.Domain.Enums;

public class TaskItem : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskBlog.Domain.Enums.TaskStatus Status { get; set; }
}
