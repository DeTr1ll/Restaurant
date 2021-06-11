using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain;
using Restaurant.Domain.Entities;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public ActionResult Index(HomeViewModel model)
        {
            IEnumerable<Dish> dishes = dataManager.Dishes.GetDishes();
            IEnumerable<Banner> banners = dataManager.Banners.GetBanners();
            HomeViewModel hvm = new HomeViewModel { Dishes = dishes, Banners = banners };
            return View(hvm);
        }
        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("contacts"));
        }
    }
}
