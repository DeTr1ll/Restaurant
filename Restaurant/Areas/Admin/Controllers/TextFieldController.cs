using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Restaurant.Domain;
using Restaurant.Domain.Entities;
using Restaurant.Service;
using System;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldController : Controller
    {
        private readonly DataManager dataManager;
        public TextFieldController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index()
        {
            return View(dataManager.TextFields.GetTextFields());
        }

      
        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new TextField() : dataManager.TextFields.GetTextFieldById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                dataManager.TextFields.SaveTextField(model);
                return RedirectToAction(nameof(TextFieldController.Index), nameof(TextFieldController).CutController());
            }
            return View(model);
        }
    }
}