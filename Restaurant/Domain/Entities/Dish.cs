using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Dish
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введіть назву страви")]
        [Display(Name = "Назва")]
        public string Title { get; set; }


        [ForeignKey("Category")]
        [Display(Name = "Категорія")]
        public Guid CategoryId { get; set; }

        [Display(Name = "Короткий опис")]
        public string Subtitle { get; set; }

        [Display(Name = "Повний опис")]
        public string Description { get; set; }

        [Display(Name = "Ціна")]
        [Column(TypeName = "money")]
        public float Price { get; set; }

        [Display(Name = "Фото")]
        public string ImagePath { get; set; }

        [Display(Name = "Видимість")]
        public bool IsVisible { get; set; }

        [Display(Name = "Від шефа")]
        public bool IsSpecial { get; set; }

        public virtual Category Category { get; set; }
    }
}
