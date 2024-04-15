using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Point.IRepository;
using Movie_Point.Models;
using Movie_Point.Repository;
using Movie_Point.ViewModel;

namespace Movie_Point.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        ICategory categoryRepository;
        public CategoryController(ICategory categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var categories = categoryRepository.GetAll();
            return View(categories);
        }
        [AllowAnonymous]
        public IActionResult GetMovies(int id) 
        {
            var movies = categoryRepository.GetMoviesByCatId(id);
            return View("\\Views\\Movie\\Index.cshtml", movies);
        }
        public IActionResult Create()
        {
            return View(new CategoryViewModel());
        }
        public IActionResult SaveNew(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var cat = new Category();
                cat.Name = category.Name;
                categoryRepository.Create(cat);
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        //public IActionResult details()
        //{
        //    var movies = categoryRepository.Details();
        //    return View(movies);
        //}
    }
}
