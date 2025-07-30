using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreAndFood.Data.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace CoreAndFood.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
            Context context = new Context();
            var dataValue = context.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.Username)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
