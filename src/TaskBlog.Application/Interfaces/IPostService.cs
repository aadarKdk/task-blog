using TaskBlog.Application.DTOs;

namespace TaskBlog.Application.Interfaces;

public interface IPostService
{
    Task<IEnumerable<PostResponseDto>> GetAllPostsAsync();
    Task<PostResponseDto?> GetPostByIdAsync(Guid id);
    Task<PostResponseDto> CreatePostAsync(CreatePostDto dto);
    Task UpdatePostAsync(Guid id, UpdatePostDto dto);
    Task DeletePostAsync(Guid id);
}
