using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain;
using Restaurant.Domain.Entities;
using Restaurant.Service;



namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public BannerController(DataManager dataManager, IWebHostEnvironment hostEnvironment) {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View(dataManager.Banners.GetBanners());
        }

        public IActionResult Edit(Guid id) {
            var entity = id == default ? new Banner() : dataManager.Banners.GetBannerById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Banner model, IFormFile imageFile) {
            if (ModelState.IsValid) {
                if(imageFile != null)
                {
                    string ext = imageFile.FileName.Split('.')[1];
                    string fileName = String.Format(@"{0}.{1}", System.Guid.NewGuid(), ext);
                    model.BannerImagePath = fileName;


                    using (var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/Banners", fileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                }
                dataManager.Banners.SaveBanner(model);
                return RedirectToAction(nameof(BannerController.Index), nameof(BannerController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id) {
            dataManager.Banners.DeleteBanner(id);
            return RedirectToAction(nameof(BannerController.Index), nameof(BannerController).CutController());
        }
    }
}
