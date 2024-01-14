using Microsoft.EntityFrameworkCore;

namespace BlazorMinimalApis.Mvc.Data;
/*
 * Para hacer migraciones correr:
 * dotnet ef migrations add NombreDeLaMigracion
 * dotnet ef database update
 */
public class RambosaDbContext : DbContext
{
    public RambosaDbContext(DbContextOptions<RambosaDbContext> options) : base(options)
    {
    }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Plato> Platos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    
    /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=(local);Database=RambosaDb;Integrated Security=True;MultipleActiveResultSets=False;TrustServerCertificate=True");*/
}

public class Plato
{
    public int PlatoId { get; set; }
    public int Precio { get; set; }
}

public class Cliente
{
    public int ClienteId { get; set; }
    public string Nombre { get; set; }
}

//Un cliente puede pedir muchos platos. Un plato puede ser pedido por muchos clientes. 
//La tabla intermedia se va a llamar pedidos. Es una relacion de muchos a muchos.

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