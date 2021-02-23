using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Models;
using MovieLibrary.Data.Configuration;

namespace MovieLibrary.Data
{
    public class MovieLibraryDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }

        public MovieLibraryDbContext(DbContextOptions<MovieLibraryDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());

            modelBuilder.ApplyConfiguration(new DirectorConfiguration());
        }
    }
}