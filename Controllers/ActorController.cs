using Microsoft.AspNetCore.Mvc;
using Movie_Point.IRepository;

namespace Movie_Point.Controllers
{
    public class ActorController : Controller
    {
        IActor repository;
        public ActorController(IActor repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowDetails(int id) 
        { 
            var actor = repository.GetById(id);
            return View(actor); 
        }
    }
}
