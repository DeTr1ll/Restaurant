using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class CategoryController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public CategoryController(DataManager dataManager, IWebHostEnvironment hostEnvironment) {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            
            IQueryable<Category> categories = dataManager.Categories.GetCategories();
            return View(categories.OrderBy(s => s.Order));
        }

        public IActionResult Edit(Guid id) {
            var entity = id == default ? new Category() : dataManager.Categories.GetCategoryById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Category model) {
            if (ModelState.IsValid) {
                dataManager.Categories.SaveCategory(model);
                return RedirectToAction(nameof(CategoryController.Index), nameof(CategoryController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id) {
            dataManager.Categories.DeleteCategory(id);
            return RedirectToAction(nameof(CategoryController.Index), nameof(CategoryController).CutController());
        }
    }
}
