using Microsoft.EntityFrameworkCore;
using _1_mandatory_movies.Models.Entities;

namespace _1_mandatory_movies.Models
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite("Filename=./Movie.db");
        }
    }
}