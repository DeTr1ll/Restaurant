using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Restaurant.Domain.Repositories.EntityFramework
{
    public class EFDishesRepository : IDishesRepository
    {
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly AppDbContext context;
        public EFDishesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Dish> GetDishes()
        {
            return context.Dishes;
        }
        public Dish GetDishById(Guid id)
        {
            return context.Dishes.FirstOrDefault(x => x.Id == id);
        }
        public void SaveDish(Dish entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteDish(Guid id)
        {
            context.Dishes.Remove(new Dish() { Id = id });
            context.SaveChanges();
        }
    }
}
