using Microsoft.EntityFrameworkCore;
using Wba.MovieRating.Core.Entities;

namespace Wba.MovieRating.Web.Data
{
    public class MovieDbContext : DbContext
    {
        //Dbsets = database tables
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
