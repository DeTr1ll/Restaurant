using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories.Abstract
{
    public interface ICategoriesRepository
    {
        IQueryable<Category> GetCategories();
        Category GetCategoryById(Guid id);
        void SaveCategory(Category entity);
        void DeleteCategory(Guid id);
    }
}
