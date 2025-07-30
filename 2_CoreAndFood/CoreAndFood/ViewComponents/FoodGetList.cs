﻿using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace CoreAndFood.ViewComponents
{
    public class FoodGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository foodRepository = new FoodRepository();
            var results = foodRepository.TList();
            return View(results);
        }
    }
}
