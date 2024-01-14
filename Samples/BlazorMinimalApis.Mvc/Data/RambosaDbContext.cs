using Microsoft.EntityFrameworkCore;

namespace BlazorMinimalApis.Mvc.Data;

public class RambosaDbContext : DbContext
{
    public RambosaDbContext(DbContextOptions<RambosaDbContext> options) : base(options)
    {
    }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }
    
    /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=(local);Database=RambosaDb;Integrated Security=True;MultipleActiveResultSets=False;TrustServerCertificate=True");*/
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; } = new();
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}