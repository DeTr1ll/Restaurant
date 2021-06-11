using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Banner
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Назва")]
        public string Title { get; set; }

        [Display(Name = "Картинка")]
        public string BannerImagePath { get; set; }
    }
}
