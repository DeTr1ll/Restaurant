using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain;
using Restaurant.Domain.Entities;
using Restaurant.Service;



namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    { 
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public EventController(DataManager dataManager, IWebHostEnvironment hostEnvironment) {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IQueryable<Event> events = dataManager.Events.GetEvents();
            return View(events.OrderBy(s => s.Date));
        }

        public IActionResult Edit(Guid id) {
            var entity = id == default ? new Event() : dataManager.Events.GetEventById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Event model, IFormFile imageFile) {
            if (ModelState.IsValid) {
                if(imageFile != null)
                {
                    string ext = imageFile.FileName.Split('.')[1];
                    string fileName = String.Format(@"{0}.{1}", System.Guid.NewGuid(), ext);
                    model.ImagePath = fileName;


                    using (var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/Events", fileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                }
                dataManager.Events.SaveEvent(model);
                return RedirectToAction(nameof(EventController.Index), nameof(EventController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Event model, Guid id) {
            
            dataManager.Events.DeleteEvent(id);
            return RedirectToAction(nameof(EventController.Index), nameof(EventController).CutController());
        }
    }
}
