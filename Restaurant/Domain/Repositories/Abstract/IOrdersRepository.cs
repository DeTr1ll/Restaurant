using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories.Abstract
{
    public interface IOrdersRepository
    {
        IQueryable<Order> GetOrders();
        Order GetOrderById(Guid id);
        void SaveOrder(Order entity);
        void DeleteOrder(Guid id);
    }
}
