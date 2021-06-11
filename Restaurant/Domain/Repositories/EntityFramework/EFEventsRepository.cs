using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Domain.Repositories.EntityFramework
{
    public class EFEventsRepository : IEventsRepository
    {
        private readonly AppDbContext context;
        public EFEventsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Event> GetEvents()
        {
            return context.Events;
        }
        public Event GetEventById(Guid id)
        {
            return context.Events.FirstOrDefault(x => x.Id == id);
        }
        public void SaveEvent(Event entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteEvent(Guid id)
        {
            context.Events.Remove(new Event() { Id = id });
            context.SaveChanges();
        }
    }
}
