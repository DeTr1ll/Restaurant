using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain;
using Restaurant.Domain.Entities;
using Restaurant.Service;



namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DishController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
       
        public DishController(DataManager dataManager, IWebHostEnvironment hostEnvironment) {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            
            IQueryable<Dish> dishes = dataManager.Dishes.GetDishes();
            return View(dishes.OrderBy(s => s.Title));
        }

        public IActionResult Edit(Guid id) {
            IEnumerable<Category> categories = dataManager.Categories.GetCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Title");
            var entity = id == default ? new Dish() : dataManager.Dishes.GetDishById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Dish model, IFormFile imageFile) {


            if (ModelState.IsValid) {
                if (imageFile != null)
                {
                    string ext = imageFile.FileName.Split('.')[1];
                    string fileName = String.Format(@"{0}.{1}", Guid.NewGuid(), ext);
                    model.ImagePath = fileName;
                    using (var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/Dishes", fileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                        
                    }
                }
                dataManager.Dishes.SaveDish(model);
                return RedirectToAction(nameof(DishController.Index), nameof(DishController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Dish model, Guid id) {
            dataManager.Dishes.DeleteDish(id);
            return RedirectToAction(nameof(DishController.Index), nameof(DishController).CutController());
        }
    }
}
