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



namespace Restaurant.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class OrderController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public OrderController(DataManager dataManager, IWebHostEnvironment hostEnvironment) {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            
            IQueryable<Order> orders = dataManager.Orders.GetOrders();
            return View(orders.OrderBy(s => s.Date));
        }

        public IActionResult Edit(Guid id) {
            var entity = id == default ? new Order() : dataManager.Orders.GetOrderById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Order model) {
            if (ModelState.IsValid) {
                dataManager.Orders.SaveOrder(model);
                return RedirectToAction(nameof(OrderController.Index), nameof(OrderController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id) {
            dataManager.Orders.DeleteOrder(id);
            return RedirectToAction(nameof(OrderController.Index), nameof(OrderController).CutController());
        }
    }
}
