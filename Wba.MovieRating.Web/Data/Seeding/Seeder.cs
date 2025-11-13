using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using Wba.MovieRating.Core.Entities;

namespace Wba.MovieRating.Web.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            #region companies
            var companies = new Company[]
            {
                new Company {Id = 1,Name = "Sony" },
                new Company {Id = 2,Name = "Columbia Pictures" },
                new Company {Id = 3,Name = "Marvel" },
            };
            #endregion
            #region Directors
            var directors = new Director[]
            {
                new Director{ Id = 1,Firstname = "Francis F.",Lastname = "Coppola"},
                new Director{ Id = 1,Firstname = "Martin",Lastname = "Scorsese"},
            };
            #endregion
            #region Actors
            var actors = new Actor[] 
            {
                new Actor{Id = 1,Firstname = "Ryan",Lastname = "Renolds"  },
                new Actor{Id = 2,Firstname = "Kim",Lastname = "Basinger"  },
                new Actor{Id = 3,Firstname = "Pamela",Lastname = "Anderson"  },
            };
            #endregion
            #region users
            var users = new User[]
            {
                new User{Id = 1, Firstname = "Bart",Lastname = "Soete"},
                new User{Id = 2, Firstname = "Joachim",Lastname = "François"},
                new User{Id = 3, Firstname = "Dries",Lastname = "Deboosere"},
            };
            #endregion
            #region Movies
            var movies = new Movie[]
            {
                new Movie {Id = 1, CompanyId = 1,Title = "Deadpool",ReleaseDate = new DateTime(2017,3,15)},
                new Movie {Id = 2, CompanyId = 2,Title = "The suicide squad",ReleaseDate = new DateTime(2018,3,16)},
                new Movie {Id = 3, CompanyId = 3,Title = "The godfather",ReleaseDate = new DateTime(1972,2,12)},
            };
            #endregion
            #region DirectorMovie
            var directorsMovies = new[]
            {
                new {DirectorsId = 1,MoviesId = 1 },
                new {DirectorsId = 2,MoviesId = 2 },
                new {DirectorsId = 1,MoviesId = 3 },
            };
            #endregion
            #region ActorMovie
            var actorsMovies = new ActorMovie[]
            {
                new ActorMovie{Id = 1, ActorId = 1,MovieId = 1,Character = "Deadpool"},
                new ActorMovie{Id = 2, ActorId = 2,MovieId = 1,Character = "Kim"},
                new ActorMovie{Id = 3, ActorId = 3,MovieId = 1,Character = "Pamela"},
                new ActorMovie{Id = 4, ActorId = 1,MovieId = 2,Character = "Danny"},
                new ActorMovie{Id = 5, ActorId = 3,MovieId = 3,Character = "Pamela"},
            };
            #endregion
            #region Ratings
            var moviesRatings = new MoviesRating[]
            {
                new MoviesRating{MovieId =1, UserId = 2, Score = 4 },
                new MoviesRating{MovieId =2, UserId = 2, Score = 5 },
                new MoviesRating{MovieId =3, UserId = 2, Score = 2 },
                new MoviesRating{MovieId =1, UserId = 1, Score = 2 },
                new MoviesRating{MovieId =2, UserId = 1, Score = 3 },
                new MoviesRating{MovieId =3, UserId = 1, Score = 5 },
                new MoviesRating{MovieId =1, UserId = 3, Score = 3 },
                new MoviesRating{MovieId =2, UserId = 3, Score = 2 },
                new MoviesRating{MovieId =3, UserId = 3, Score = 1 },
            };
            #endregion
            //hasdata methods
            #region hasdata methods
            modelBuilder.Entity<Company>().HasData(companies);
            modelBuilder.Entity<Actor>().HasData(actors);
            modelBuilder.Entity<Director>().HasData(directors);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Movie>().HasData(movies);
            modelBuilder.Entity<ActorMovie>().HasData(actorsMovies);
            modelBuilder.Entity<MoviesRating>().HasData(moviesRatings);
            //many to many by convention => use table name
            modelBuilder.Entity($"{nameof(Director)}{nameof(Movie)}").HasData(directorsMovies);
            #endregion
        }
    }
}
