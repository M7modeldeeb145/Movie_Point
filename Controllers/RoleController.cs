using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_Point.ViewModel;

namespace Movie_Point.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> rolemanager;

        public RoleController(RoleManager<IdentityRole> rolemanager)
        {
            this.rolemanager = rolemanager;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRoleVM userRoleVM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole(userRoleVM.Name);
                var result = await rolemanager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home") ;
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"Invalid Role");
                }
            }
            return View(userRoleVM);
        }
    }
}
