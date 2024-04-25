using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Point.IRepository;
using Movie_Point.Models;
using Movie_Point.ViewModel;

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
        [HttpGet]
        public IActionResult GetAll()
        {
            var actors = repository.ReadAll();
            return View(actors);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ActorViewModel());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult SaveNew(ActorViewModel actor)
        {
            if(ModelState.IsValid)
            {
                var act = new Actor();
                act.FirstName = actor.FirstName;
                act.LastName = actor.LastName;
                act.Bio = actor.Bio;
                act.ProfilePicture = actor.ProfilePicture;
                act.News = actor.News;
                repository.Create(act);
                return RedirectToAction("GetAll");
            }
            return View("Create");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var actor = repository.GetById(id);
            if (actor != null)
            {
                repository.Delete(id);
                return RedirectToAction("GetAll");
            }
            return View("Home", "Error");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var actor = repository.GetById(id);
            if (actor == null)
            {
                return View("GetAll");
            }
            ActorViewModel actorViewModel = new ActorViewModel()
            {
                LastName = actor.LastName,
                FirstName = actor.FirstName,
                Bio = actor.Bio,
                ProfilePicture = actor.ProfilePicture,
                News = actor.News
            };
            return View(actorViewModel);
        }
        //[Authorize(Roles = "Admin")]
        //public IActionResult SaveEdit(ActorViewModel actor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //       var act = repository.GetById(actor.Id);
        //        repository.Update(actor);
        //        return RedirectToAction("GetAlll",act);
        //    }
        //    return View("Edit");
        //}
    }
}
