using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Library;

    internal class CatalogContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
            
        }

    public class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=labs4;Username=postgres;Password=123");

            return new CatalogContext(optionsBuilder.Options);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasKey(k => k.Id);
            modelBuilder.Entity<Director>().HasKey(k => k.Id);

            modelBuilder.Entity<Director>()
                        .HasMany(d => d.Movies)
                        .WithOne(m => m.Director)
                        .HasForeignKey(m => m.DirectorId);
        }
    }


// Add-Migration InitialMigration -Project Project1.Library -StartupProject Project1.Library
// Update-Database -Project Project1.Library -StartupProject Project1.Library
