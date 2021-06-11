using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введите название категории")]
        [Display(Name = "Назва")]
        public string Title { get; set; }

        [Display(Name = "Порядок")]
        public int Order { get; set; }

        [Display(Name = "Видимість")]
        public bool IsVisible { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }

    }
}
