using CoreMvcDepartman.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcDepartman.Controllers
{
    public class DepartmanController : Controller
    {
        Context context = new Context();

        [Authorize]
        public IActionResult Index()
        {
            var degerler = context.Departmanlar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniDepartman()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniDepartman(Departman d)
        {
            context.Departmanlar.Add(d);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DepartmanSil(int id)
        {
            var silinecekDepartman = context.Departmanlar.Find(id);
            context.Departmanlar.Remove(silinecekDepartman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DepartmanGetir(int id)
        {
            var departman = context.Departmanlar.Find(id);
            return View("DepartmanGetir", departman);
        }
        public IActionResult DepartmanGuncelle(Departman d)
        {
            var departman = context.Departmanlar.Find(d.DepartmanId);
            departman.DepartmanAd = d.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DepartmanDetay(int id)
        {
            var personeller = context.Personeller.Where(x => x.DepartmanId == id).ToList();
            var departmanAd = context.Departmanlar.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.departmanAd = departmanAd;
            return View(personeller);
        }
    }
}
