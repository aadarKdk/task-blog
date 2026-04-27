using Microsoft.EntityFrameworkCore;
using TaskBlog.Application.Interfaces;
using TaskBlog.Domain.Entities;
using TaskBlog.Infrastructure.Data;

namespace TaskBlog.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task<Post?> GetPostByIdAsync(Guid id)
    {
        return await _context.Posts.FindAsync(id);
    }

    public async Task AddPostAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePostAsync(Post post)
    {
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePostAsync(Post post)
    {
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
    }
}
