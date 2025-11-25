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

        public IActionResult Index()
        {
            //get the movies
            var movies = _movieDbContext
                .Movies.ToList();
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
    }
}
