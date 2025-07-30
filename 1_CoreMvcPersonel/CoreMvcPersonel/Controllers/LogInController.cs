using CoreMvcDepartman.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreMvcDepartman.Controllers
{
    public class LogInController : Controller
    {
        Context context = new Context();
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }
        public async Task<IActionResult> GirisYap(Admin p)
        {
            var bilgiler = context.Adminler.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);
            if(bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.Kullanici)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Personel");
            }
            return View();
        }
    }
}
