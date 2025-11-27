using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wba.MovieRating.Core.Entities;
using Wba.MovieRating.Web.Data;
using Wba.MovieRating.Web.ViewModels;

namespace Wba.MovieRating.Web.Controllers
{
    public class MoviesController : Controller
    {
        //declare the database context
        private readonly MovieDbContext _movieDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;



        public MoviesController(MovieDbContext movieDbContext, IWebHostEnvironment webHostEnvironment)
        {
            //inject the database context = constructor injection
            _movieDbContext = movieDbContext;
            _webHostEnvironment = webHostEnvironment;
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
                //short if to handle empty ratings 
                AverageRating = movie.Ratings.Count() == 0 ? 0 : movie.Ratings.Average(r => r.Score)
            };
            //check if image is null
            if(movie.Image is null)
            {
                moviesInfoViewModel.Image = "https://placehold.co/600x400";
            }
            else
            {
                moviesInfoViewModel.Image = $"/images/{movie.Image}";
            }
            //pass to the view
            return View(moviesInfoViewModel);
        }
        //crud
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //declare the viewmodel
            //load the data for the dropdowns
            //set the releasedate to today

            var moviesCreateViewModel = new MoviesCreateViewModel
            {
                Companies = await _movieDbContext.Companies
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync(),
                Directors = await _movieDbContext.Directors
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.Firstname} {d.Lastname}"
                })
                .ToListAsync(),
                Actors = await _movieDbContext.Directors
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.Firstname} {a.Lastname}",
                })
                .ToListAsync(),
                ReleaseDate = DateTime.Now
            };
            //pass to the view
            return View(moviesCreateViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MoviesCreateViewModel moviesCreateViewModel)
        {
            //validate the data in the viewmodel
                //custom validation if necessary
                if(moviesCreateViewModel.ReleaseDate >= DateTime.Now)
                {
                    //add error to modelstate
                }
                //check modelstate
                if(!ModelState.IsValid)
                {
                    //reload the dropdowns
                    return View(moviesCreateViewModel);
                }
            //create the movie
            var movie = new Movie
            {
                Title = moviesCreateViewModel.Title,
                ReleaseDate = moviesCreateViewModel.ReleaseDate,
                CompanyId = moviesCreateViewModel.CompanyId,
                Image = "https://placehold.co/600x400",//set default placeholder image
                Directors = await _movieDbContext.Directors
                            .Where(d => moviesCreateViewModel.DirectorIds
                            .Contains(d.Id)).ToListAsync(),
            };
            movie.Actors = moviesCreateViewModel.ActorIds.Select(a =>
                new ActorMovie
                {
                    ActorId = a,
                    MovieId = movie.Id,
                }).ToList();
            //handle file upload if necessary
            if (moviesCreateViewModel.Image is not null)
            {
                //upload movie
                
                //create unique filename
                var filename = $"{Guid.NewGuid()}_{moviesCreateViewModel.Image.FileName}";
                //create path to wwwroot/images
                var pathToImgFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    //check if directory exists
                if(!Directory.Exists(pathToImgFolder))
                {
                    //create directory
                    Directory.CreateDirectory(pathToImgFolder);
                }
                //create fullpath to file
                var fullPathToFile = Path.Combine(pathToImgFolder, filename);
                    //copy file using filestream
                using(var filestream = new FileStream(fullPathToFile,FileMode.Create))
                {
                    await moviesCreateViewModel.Image.CopyToAsync(filestream);
                }
                //set movie image to filename
                movie.Image = filename;
            }
            //add to the tracking context
            _movieDbContext.Movies.Add(movie);
            //save to the database
            _movieDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
