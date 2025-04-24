using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Models.ViewModels;

namespace ToDo.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationUser> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              RoleManager<ApplicationUser> roleManager){

                                _userManager = userManager;
                                _signInManager = signInManager;
                                _roleManager = roleManager;
        }


        [HttpGet]
        public IActionResult Register(){
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regmodel){
            if(!ModelState. IsValid) {
                return View();
            }

            var user = new ApplicationUser(){
                UserName = regmodel.Email,  // for unique username
                Email = regmodel.Email,
                Fullname = regmodel.Fullname
            };

                // creates a new user method
            var result = await _userManager.CreateAsync(user, regmodel.Password);
            if (result.Succeeded){
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index" , "Home");
            }

            foreach(var error in result.Errors){
                ModelState.AddModelError("", error.Description);
            }
            return View(regmodel);
        }



        [HttpGet]
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel logmodel){
            if(!ModelState.IsValid){
                return View();
            }

            // no need to create an existed user
            var result = await _signInManager.PasswordSignInAsync(logmodel.Email, logmodel.Password, logmodel.RememberMe, false);
            if (result.Succeeded){
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(logmodel);
        }


        public async Task<IActionResult> Logout(){
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



    }
}
