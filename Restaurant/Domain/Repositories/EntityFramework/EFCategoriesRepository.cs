using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Domain.Repositories.EntityFramework
{
    public class EFCategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext context;
        public EFCategoriesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Category> GetCategories()
        {
            return context.Categories;
        }
        public Category GetCategoryById(Guid id)
        {
            return context.Categories.FirstOrDefault(x => x.Id == id);
        }
        public void SaveCategory(Category entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteCategory(Guid id)
        {
            context.Categories.Remove(new Category() { Id = id });
            context.SaveChanges();
        }
    }
}
