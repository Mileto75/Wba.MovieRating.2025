using Microsoft.EntityFrameworkCore;
using Wba.MovieRating.Core.Entities;

namespace Wba.MovieRating.Web.Data
{
    public class MovieDbContext : DbContext
    {
        //Dbsets = database tables
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MoviesRating> Ratings { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Movie
            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(100);
            #endregion
            #region User
            modelBuilder.Entity<User>()
                .Property(m => m.Firstname)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(m => m.Lastname)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                .Property(m => m.Lastname)
                .IsRequired()
                .HasMaxLength(100);
            #endregion
            #region Rating
            modelBuilder.Entity<MoviesRating>()
                .Property(m => m.Score)
                .IsRequired();
            modelBuilder.Entity<MoviesRating>()
                .ToTable(t =>
                t.HasCheckConstraint("chk_range", "score BETWEEN 1 AND 5"));
            modelBuilder.Entity<MoviesRating>()
                .HasKey(m => new { m.MovieId, m.UserId });

            #endregion
            #region Actor
            modelBuilder.Entity<Actor>()
                .Property(m => m.Firstname)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Actor>()
                .Property(m => m.Lastname)
                .IsRequired()
                .HasMaxLength(100);
            //combined primary key
            #endregion
            #region Director

            #endregion
            #region Company
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
