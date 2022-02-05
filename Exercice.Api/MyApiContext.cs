using Exercice.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MyApiContext : DbContext
{
    public MyApiContext(DbContextOptions<MyApiContext> options) : base(options)
    {

    }

    // Les tables ici pour la creation
    public DbSet<UserEntity> UserEntity { get; set; }
    public DbSet<OrderEntity> OrderEntity { get; set; }
    public DbSet<ProductEntity> ProductEntity { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // Le code ci-dessous évite la suppression en cascade par foreign key.
            entityType.GetForeignKeys()
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
        }
        base.OnModelCreating(modelBuilder);
    }
}