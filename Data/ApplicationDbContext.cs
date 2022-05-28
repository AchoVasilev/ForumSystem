namespace Data;
using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var entityTypes = builder.Model.GetEntityTypes().ToList();
        var foreignKeys = entityTypes.SelectMany(x => x.GetForeignKeys()
            .Where(k => k.DeleteBehavior == DeleteBehavior.Cascade));

        foreach (var foreignKey in foreignKeys)
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(builder);
    }
}
