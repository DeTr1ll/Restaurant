using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories.Abstract
{
    public interface IDishesRepository
    {
        IQueryable<Dish> GetDishes();
        Dish GetDishById(Guid id);
        void SaveDish(Dish entity);
        void DeleteDish(Guid id);
    }
}
