using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories.Abstract
{
    public interface IEventsRepository
    {
        IQueryable<Event> GetEvents();
        Event GetEventById(Guid id);
        void SaveEvent(Event entity);
        void DeleteEvent(Guid id);
    }
}
