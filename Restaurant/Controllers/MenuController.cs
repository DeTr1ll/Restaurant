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
    public class MenuController : Controller
    {
        private readonly DataManager dataManager;
        public MenuController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        
        
        // GET: MenuController
        public ActionResult Index(MenuViewModel model)
        {
            IEnumerable<Category> categories = dataManager.Categories.GetCategories();
            IEnumerable<Dish> dishes = dataManager.Dishes.GetDishes();
            MenuViewModel mvm = new MenuViewModel { Dishes = dishes, Categories = categories };
            return View(mvm);
        }

        // GET: MenuController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(dataManager.Dishes.GetDishById(id));
        } 
    }
}
