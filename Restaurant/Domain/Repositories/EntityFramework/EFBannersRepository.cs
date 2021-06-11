using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Domain.Repositories.EntityFramework
{
    public class EFBannersRepository : IBannersRepository
    {
        private readonly AppDbContext context;
        public EFBannersRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Banner> GetBanners()
        {
            return context.Banners;
        }
        public Banner GetBannerById(Guid id)
        {
            return context.Banners.FirstOrDefault(x => x.Id == id);
        }
        public void SaveBanner(Banner entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteBanner(Guid id)
        {
            context.Banners.Remove(new Banner() { Id = id });
            context.SaveChanges();
        }
    }
}
