using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories.Abstract
{
    public interface IBannersRepository
    {
        IQueryable<Banner> GetBanners();
        Banner GetBannerById(Guid id);
        void SaveBanner(Banner entity);
        void DeleteBanner(Guid id);
    }
}
