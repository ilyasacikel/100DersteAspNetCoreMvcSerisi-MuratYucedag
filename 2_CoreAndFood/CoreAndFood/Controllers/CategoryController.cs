using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        public IActionResult Index(string p)
        {
            if (!p.IsNullOrEmpty())
            {
                return View(categoryRepository.List(x => x.CategoryName == p));
            }
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(category);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            Category ct = new Category
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryID = x.CategoryID
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x = categoryRepository.TGet(p.CategoryID);
            x.CategoryName = p.CategoryName;
            x.CategoryID = p.CategoryID;
            x.CategoryDescription = p.CategoryDescription;
            x.Status = true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
