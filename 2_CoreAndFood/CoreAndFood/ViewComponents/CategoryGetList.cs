﻿using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace CoreAndFood.ViewComponents
{
    public class CategoryGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categoryList = categoryRepository.TList();
            return View(categoryList);
        }
    }
}
