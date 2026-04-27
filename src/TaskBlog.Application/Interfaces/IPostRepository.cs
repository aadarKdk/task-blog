using TaskBlog.Domain.Entities;

namespace TaskBlog.Application.Interfaces;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<Post?> GetPostByIdAsync(Guid id);
    Task AddPostAsync(Post post);
    Task UpdatePostAsync(Post post);
    Task DeletePostAsync(Post post);
}
