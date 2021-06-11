using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain;
using Restaurant.Domain.Entities;
using Restaurant.Service;

namespace Restaurant.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Dish> Dishes { get; set; }
        public IEnumerable<Banner> Banners { get; set; }
    }
}

