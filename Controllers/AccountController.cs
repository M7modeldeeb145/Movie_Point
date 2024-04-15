using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_Point.Models;
using Movie_Point.ViewModel;

namespace Movie_Point.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Registeration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registeration(ApplicationUserVM userVM)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    Email = userVM.Email,
                    PasswordHash= userVM.Password,
                    UserName = userVM.UserName,
                }; 
                var result = await userManager.CreateAsync(user,userVM.Password);
                await userManager.AddToRoleAsync(user , "User");
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user,true);
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            return View(userVM);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Login(UserLoginVM UserVM)
        {
            if (ModelState.IsValid)
            {
                var result = await userManager.FindByNameAsync(UserVM.UserName);
                if(result!=null)
                {
                    bool Check = await userManager.CheckPasswordAsync(result,UserVM.Password);
                    if(Check)
                    {
                        await signInManager.SignInAsync(result,UserVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    //Invalid Password
                    ModelState.AddModelError("InvalidPassword", "Invalid Password");
                }
                ModelState.AddModelError("InvalidUser", "Invalid User");
            }
            return View(UserVM);
        }
        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
