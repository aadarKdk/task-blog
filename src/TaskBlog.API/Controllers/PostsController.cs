using Microsoft.AspNetCore.Mvc;
using TaskBlog.Application.DTOs;
using TaskBlog.Application.Interfaces;

namespace TaskBlog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var post = await _postService.GetPostByIdAsync(id);

        if (post == null)
            return NotFound();

        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _postService.CreatePostAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePostDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _postService.UpdatePostAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _postService.DeletePostAsync(id);
        return NoContent();
    }
}
