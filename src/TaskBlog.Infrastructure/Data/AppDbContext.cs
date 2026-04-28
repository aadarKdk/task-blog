using Microsoft.EntityFrameworkCore;
using TaskBlog.Domain.Entities;

namespace TaskBlog.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.ToTable("tasks");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title).IsRequired().HasMaxLength(255);

            entity.Property(x => x.Status).IsRequired();

            entity.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasIndex(x => x.Title);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("posts");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title).IsRequired().HasMaxLength(255);

            entity.Property(x => x.Content).IsRequired();

            entity.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasIndex(x => x.CreatedAt);
        });
    }
}
