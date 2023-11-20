using LangelandsPizza.Models.Dbfiles;
using LangelandsPizza.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LangelandsPizza.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppDbContext _appDbContext;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appDbContext = appDbContext;
        }

        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Fooditem");
        }

        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid) 
            {
                return View(login);
            }

            var user = await _userManager.FindByEmailAsync(login.EmailAdress);

            if(user != null)
            {
                var Check = await _userManager.CheckPasswordAsync(user, login.Password);
                if (Check)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Fooditem");
                    }
                }
                TempData["Fejl"] = "Forkert Brugernavn eller kode, prøv igen";
                return View(login);

            }


            TempData["Fejl"] = "Forkert Brugernavn eller kode, prøv igen";
            return View(login);

        }
    }
}
