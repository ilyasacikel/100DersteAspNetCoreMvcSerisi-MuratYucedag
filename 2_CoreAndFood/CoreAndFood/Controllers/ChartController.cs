using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace CoreAndFood.Controllers
{
    [AllowAnonymous]

    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                proname = "Lcd",
                stock = 75
            });
            cs.Add(new Class1()
            {
                proname = "Usb Disk",
                stock = 220
            });
            return cs;
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeFoodResult()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using(var context = new Context())
            {
                cs2 = context.Foods.Select(x => new Class2()
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();
            }
            return cs2;
        }
        public IActionResult Statistics()
        {
            Context context = new Context();
            var d1 = context.Foods.Count();
            ViewBag.d1 = d1;
            var d2 = context.Categories.Count();
            ViewBag.d2 = d2;
            #region Yöntem-1
            //var d3 = context.Foods.Include(x=> x.Category).Where(x => x.Category.CategoryName == "Fruits").Count();
            //ViewBag.d3 = d3;
            //var d4 = context.Foods.Include(x=> x.Category).Where(x => x.Category.CategoryName == "Vegetables").Count();
            //ViewBag.d4 = d4;
            #endregion
            var foid = context.Categories.Where(x => x.CategoryName == "Fruits").Select(y => y.CategoryID).FirstOrDefault();
            var d3 = context.Foods.Where(x => x.CategoryID == foid).Count();
            ViewBag.d3 = d3;
            var d4 = context.Foods.Where(x => x.CategoryID == context.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = d4;

            var d5 = context.Foods.Sum(x => x.Stock);
            ViewBag.d5 = d5;

            var d6 = context.Foods.Where(x => x.CategoryID == context.Categories.Where(y => y.CategoryName == "Legumes").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = d6;

            var d7 = context.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = d7;
            var d8 = context.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = d8;

            var d9 = context.Foods.Average(x => x.Price).ToString("#.##");
            ViewBag.d9 = d9;

            var d10 = context.Foods.Where(x => x.CategoryID == context.Categories.Where(x => x.CategoryName == "Fruits").Select(y => y.CategoryID).FirstOrDefault()).Sum(z => z.Stock);
            ViewBag.d10 = d10;
            var d11 = context.Foods.Where(x => x.CategoryID == context.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault()).Sum(z => z.Stock);
            ViewBag.d11 = d11;

            var d12 = context.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.d12 = d12;
            return View();
        }
    }
}
