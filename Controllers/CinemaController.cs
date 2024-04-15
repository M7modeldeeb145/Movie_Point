using Microsoft.AspNetCore.Mvc;
using Movie_Point.IRepository;

namespace Movie_Point.Controllers
{
    public class CinemaController : Controller
    {
        ICinema cinema;
        public CinemaController(ICinema cinema)
        {
            this.cinema = cinema;
        }
        public IActionResult Index()
        {
            var cinemas = cinema.GetAll();
            return View(cinemas);
        }
        public IActionResult GetMovies(int id)
        {
            var movies = cinema.GetMoviesWithCinemaId(id);
            return View("\\Views\\Movie\\Index.cshtml", movies);
        }
    }
}
