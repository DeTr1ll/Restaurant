using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain;
using Restaurant.Domain.Entities;
using Restaurant.Service;

namespace Restaurant.Models
{
    public class MenuViewModel
    {
        public IEnumerable<Dish> Dishes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
