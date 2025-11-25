using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wba.MovieRating.Web.Data;
using Wba.MovieRating.Web.ViewModels;

namespace Wba.MovieRating.Web.Controllers
{
    public class MoviesController : Controller
    {
        //declare the database context
        private readonly MovieDbContext _movieDbContext;

        public MoviesController(MovieDbContext movieDbContext)
        {
            //inject the database context = constructor injection
            _movieDbContext = movieDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //get the movies
            var movies = await _movieDbContext
                .Movies.ToListAsync();
            
            //fill the model => object initialisation
            var moviesIndexViewModel = new MoviesIndexViewModel
            {
                Movies = movies.Select(m => new
                BaseViewModel
                {
                    Id = m.Id,
                    Value = m.Title
                })
            };
            
            //pass to the view
            return View(moviesIndexViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Info(long id)
        {
            //get the movie use id
            var movie = await _movieDbContext.Movies
                .Include(m => m.Company)
                .Include(m => m.Actors)
                .ThenInclude(a => a.Actor)
                .Include(m => m.Directors)
                .Include(m => m.Ratings)
                .AsSplitQuery()
                .FirstOrDefaultAsync(m => m.Id == id);
            //check if null
            if(movie is null)
            {
                return NotFound();
            }
            //fill the model
            var moviesInfoViewModel = new MoviesInfoViewModel
            {
                Id = movie.Id,
                Value = movie.Title,
                ReleaseDate = (DateTime)movie.ReleaseDate,
                Actors = movie.Actors.Select(a => new BaseViewModel
                {
                    Id = a.Id,
                    Value = $"{a.Actor.Firstname} {a.Actor.Lastname}"
                }),
                Directors = movie.Directors.Select(d => new BaseViewModel
                {
                    Id = d.Id,
                    Value = $"{d.Firstname} {d.Lastname}"
                }),
                Company = new BaseViewModel 
                {
                    Id = movie.Company.Id,
                    Value = movie.Company.Name
                },
                AverageRating = movie.Ratings.Average(r => r.Score)
            };
            //pass to the view
            return View(moviesInfoViewModel);
        }

    }
}
