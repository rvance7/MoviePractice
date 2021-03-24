using Microsoft.AspNetCore.Mvc;
using Assignment3.Models;
using Microsoft.Extensions.Logging;
using Assignment3.Models.ViewModels;
using System.Linq;

//home controller
namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private IMovieRepository _repository;
        private MovieDbContext context { get; set; }
        public HomeController(ILogger<HomeController> logger, IMovieRepository repository, MovieDbContext con)
        {
            _logger = logger;
            _repository = repository;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShowMovies() => View(context.Movies);

        [HttpPost]
        public IActionResult Edit(MoviesResponse edit)
        {
            //var x = context.Movies.Where(m => m.MovieID == MovieNumber);

            return View("Edit", edit);
        }

        [HttpPost]
        public IActionResult EditMovies(MoviesResponse edit)
        {
            IQueryable<MoviesResponse> editMovie = context.Movies.Where(m => m.MovieID == edit.MovieID);
            foreach (var x in editMovie)
            {
                x.Category = edit.Category;
                x.Title = edit.Title;
                x.Year = edit.Year;
                x.Director = edit.Director;
                x.Rating = edit.Rating;
                x.Edited = edit.Edited;
                x.LentTo = edit.LentTo;
                x.Notes = edit.Notes;
            }
            context.SaveChanges();
            return View("Confirmation");
        }

        [HttpPost]
        public IActionResult Remove(long MovieID)
        {
            IQueryable<MoviesResponse> removeMovie = context.Movies.Where(m => m.MovieID == MovieID);

            foreach (var x in removeMovie)
            {
                context.Movies.Remove(x);
            }
  
            context.SaveChanges();

            return View("Confirmation");
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {

            return View();
            //return View(new MovieViewModel
            //{
            //    Movies = _repository.Movies
            //});
        }

        [HttpPost]
        public IActionResult Movies(MoviesResponse moviesResponse)
        {
            if (ModelState.IsValid)
            {
                //MovieViewModel movie = new MovieViewModel
                {
                    context.Movies.Add(moviesResponse);
                    context.SaveChanges();
                };
                return View("Confirmation");
            }
            else
            {
                return View(moviesResponse);
            }
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Assignment3.Models;

////controller for the app
//namespace Assignment3.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        private IMovieRepository repository;

//        public HomeController(IMovieRepository repo)
//        {
//            repository = repo;
//        }

//        public IActionResult Index() => View(repository.Movies);

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        //public IActionResult Index()
//        //{
//        //    return View();
//        //}

//        //[HttpGet]
//        //public IActionResult Movies()
//        //{

//        //    return View();
//        //}

//        //[HttpPost]
//        //public IActionResult Movies(MoviesResponse moviesResponse)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        TempStorage.AddMovie(moviesResponse);
//        //        return View("Confirmation", moviesResponse);
//        //    }
//        //    else
//        //    {
//        //        return View(moviesResponse);
//        //    }
//        //}

//        //public IActionResult ShowMovies()
//        //{
//        //    return View(TempStorage.Applications.Where(x => x.Title != "Independance Day"));
//        //}


//        public IActionResult MyPodcasts()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
