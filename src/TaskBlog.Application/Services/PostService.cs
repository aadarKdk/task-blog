using TaskBlog.Application.DTOs;
using TaskBlog.Application.Interfaces;
using TaskBlog.Domain.Entities;

namespace TaskBlog.Application.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<PostResponseDto>> GetAllPostsAsync()
    {
        var posts = await _postRepository.GetAllPostsAsync();

        return posts.Select(p => new PostResponseDto
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            IsPublished = p.IsPublished,
            CreatedAt = p.CreatedAt,
        });
    }

    public async Task<PostResponseDto?> GetPostByIdAsync(Guid id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);

        if (post == null)
            return null;

        return new PostResponseDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            IsPublished = post.IsPublished,
            CreatedAt = post.CreatedAt,
        };
    }

    public async Task<PostResponseDto> CreatePostAsync(CreatePostDto dto)
    {
        var post = new Post
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Content = dto.Content,
            CreatedAt = DateTime.UtcNow,
            IsPublished = false,
        };

        await _postRepository.AddPostAsync(post);

        return new PostResponseDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            IsPublished = post.IsPublished,
            CreatedAt = post.CreatedAt,
        };
    }

    public async Task UpdatePostAsync(Guid id, UpdatePostDto dto)
    {
        var existing = await _postRepository.GetPostByIdAsync(id);

        if (existing == null)
            throw new KeyNotFoundException("Post not found");

        existing.Title = dto.Title;
        existing.Content = dto.Content;
        existing.IsPublished = dto.IsPublished;

        await _postRepository.UpdatePostAsync(existing);
    }

    public async Task DeletePostAsync(Guid id)
    {
        var existing = await _postRepository.GetPostByIdAsync(id);

        if (existing == null)
            throw new KeyNotFoundException("Post not found");

        await _postRepository.DeletePostAsync(existing);
    }
}
