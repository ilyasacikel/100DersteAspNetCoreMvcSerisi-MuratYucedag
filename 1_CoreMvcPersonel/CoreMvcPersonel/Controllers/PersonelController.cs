using CoreMvcDepartman.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreMvcDepartman.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();
        
        [Authorize]
        public IActionResult Index()
        {
            var degerler = context.Personeller.Include(x=>x.Departman).ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in context.Departmanlar.ToList()
                                             select new SelectListItem()
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanId.ToString()
                                             }).ToList();
            ViewBag.departmanlar = degerler;
            return View();
        }
        public IActionResult YeniPersonel(Personel p)
        {
            var departman = context.Departmanlar.Where(x => x.DepartmanId == p.Departman.DepartmanId).FirstOrDefault();
            p.Departman = departman;
            context.Personeller.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult PersonelGuncelle(int id)
        {
            var deger = context.Personeller.Find(id);
            List<SelectListItem> degerler = (from x in context.Departmanlar.ToList()
                                             select new SelectListItem()
                                             {
                                                 Value = x.DepartmanId.ToString(),
                                                 Text = x.DepartmanAd
                                             }).ToList();
            ViewBag.departmanlar = degerler;
            return View(deger);
        }
        [HttpPost]
        public IActionResult PersonelGuncelle(Personel p)
        {
            var personel = context.Personeller.Find(p.PersonelId);
            personel.Ad = p.Ad;
            personel.Soyad = p.Soyad;
            personel.Sehir = p.Sehir;
            personel.DepartmanId = p.DepartmanId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult PersonelSil(int id)
        {
            var degerler = context.Personeller.Find(id);
            context.Personeller.Remove(degerler);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
