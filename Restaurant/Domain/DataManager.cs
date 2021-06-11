using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain.Repositories.Abstract;

namespace Restaurant.Domain
{
    public class DataManager
    {
        public IBannersRepository Banners { get; set; }
        public ICategoriesRepository Categories { get; set; }
        public IDishesRepository Dishes { get; set; }
        public IEventsRepository Events { get; set; }
        public IOrdersRepository Orders { get; set; }
        public ITextFieldsRepository TextFields { get; set; }

        public DataManager(IBannersRepository bannersRepository, ICategoriesRepository categoriesRepository, IDishesRepository dishesRepository, IEventsRepository eventsRepository, IOrdersRepository ordersRepository, ITextFieldsRepository textFieldsRepository) {
            Banners = bannersRepository;
            Categories = categoriesRepository;
            Dishes = dishesRepository;
            Events = eventsRepository;
            Orders = ordersRepository;
            TextFields = textFieldsRepository;
        }
    }
}
