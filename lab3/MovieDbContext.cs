using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labbb3.Library.Models;

namespace labbb3.Library.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=my_db;Username=postgres;Password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasIndex(t => t.Id);

            
            modelBuilder.Entity<Movie>()
                        .HasOne(m => m.Director)
                        .WithMany(d => d.Movies)
                        .HasForeignKey(m => m.DirectorId);
        }
    }
}
