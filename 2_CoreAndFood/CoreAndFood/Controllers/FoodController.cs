using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        Context context = new Context();
        FoodRepository foodRepository = new FoodRepository();
        public IActionResult Index(int page=1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page,7));
        }

        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(urunekle p)
        {
            Food food = new Food();
            if(p.ImageURL != null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newImgName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resimler/",newImgName);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                food.ImageURL = newImgName;
            }
            food.Name = p.Name;
            food.Description = p.Description;
            food.Price = p.Price;
            food.Stock = p.Stock;
            food.CategoryID = p.CategoryID;
            foodRepository.TAdd(food);
            return RedirectToAction("Index");
        }
        public IActionResult FoodDelete(int id)
        {
            foodRepository.TDelete(new Food { FoodID = id });
            return RedirectToAction("Index");
        }
        public IActionResult FoodGet(int id)
        {
            var x = foodRepository.TGet(id);
            List<SelectListItem> values = (from y in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            Food food = new Food
            {
                FoodID = x.FoodID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Description = x.Description,
                Stock = x.Stock,
                Price = x.Price,
                ImageURL = x.ImageURL
            };

            ViewBag.values = values;
            return View(food);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var x = foodRepository.TGet(p.FoodID);
            x.CategoryID = p.CategoryID;
            x.Name = p.Name;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            x.Stock = p.Stock;
            x.Description = p.Description;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
