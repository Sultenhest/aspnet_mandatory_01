using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _1_mandatory_movies.Models.Entities;

namespace _1_mandatory_movies.Models
{
    public class _1_mandatory_moviesContext : DbContext
    {
        public _1_mandatory_moviesContext (DbContextOptions<_1_mandatory_moviesContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}