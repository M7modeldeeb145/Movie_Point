using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Point.Data;
using Movie_Point.IRepository;
using Movie_Point.Models;
using Movie_Point.Repository;
using Movie_Point.ViewModel;

namespace Movie_Point.Controllers
{
    public class MovieController : Controller
    {
        List<Movie> movies = new List<Movie>();
        IMovie repository;
        public MovieController(IMovie repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            var movies =repository.ReadAllWithCinema_Category();
            return View(movies);
        }
        [Authorize( Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["categories"] = repository.GetCategories();
            ViewData["cinemas"] = repository.GetCinemas();
            return View(new MovieViewModel());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult SaveNew(MovieViewModel movie)
        {
            if(ModelState.IsValid)
            {
                var mov = new Movie();
                mov.Name = movie.Name;
                mov.Description = movie.Description;
                mov.Price = movie.Price;
                mov.MovieStatus = movie.MovieStatus;
                mov.StartDate = movie.StartDate;
                mov.EndDate = movie.EndDate;
                mov.CategoryId = movie.CategoryId;
                mov.CinemaId = movie.CinemaId;
                mov.ImgUrl = movie.ImgUrl;
                mov.TrailerUrl = movie.TrailerUrl;
                repository.Create(mov);
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var movie = repository.Get(id);
            if(movie == null)
            {
                return RedirectToAction("Index");
            }
            MovieViewModel movieViewModel = new MovieViewModel() { Name=movie.Name,Id=movie.Id,Description=movie.Description,Price=movie.Price,StartDate=movie.StartDate,EndDate=movie.EndDate,ImgUrl=movie.ImgUrl,TrailerUrl=movie.TrailerUrl,CategoryId=movie.CategoryId,CinemaId=movie.CinemaId,MovieStatus=movie.MovieStatus};
            ViewData["categories"] = repository.GetCategories();
            ViewData["cinemas"] = repository.GetCinemas();
            return View(movieViewModel);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult SaveEdit(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                var mov = repository.Get(movie.Id);
                repository.Update(movie);
                return RedirectToAction("Index",mov);
            }
            return View("Edit");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            repository.Delete(id); 
            return RedirectToAction("Index");
        }
        public IActionResult ShowDetalis(int id)
        {
            var movie =repository.GetMovieWithDept(id);
            return View(movie);
        }
        public IActionResult Search(string name)
        {
            var movie = repository.Search(name);
            return View(movie);
        }
        [Authorize(Roles = "User")]
        public IActionResult BookTicket(int id)
        {
            var movie =repository.Get(id);
            movies.Add(movie);
            return View(movies);
        }
    }
}
