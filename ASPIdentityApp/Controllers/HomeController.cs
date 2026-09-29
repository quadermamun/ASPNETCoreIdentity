using ASPIdentityApp.Data;
using ASPIdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace ASPIdentityApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        // Or if using default ASP.NET Core Identity:
        //private readonly SignInManager _signInManager;

        public HomeController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Protects against CSRF attacks
        public async Task<IActionResult> Logout()
        {
            // Clears the user's authentication cookie
            await _signInManager.SignOutAsync();

            // Redirect the user to the home page or a public page
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
