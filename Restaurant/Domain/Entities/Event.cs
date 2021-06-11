using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Event
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введите название категории")]
        [Display(Name = "Назва")]
        public string Title { get; set; }

        [Display(Name = "Короткий опис")]
        public string Subtitle { get; set; }

        [Display(Name = "Повний опис")]
        public string Description { get; set; }

        [Display(Name = "Фото")]
        public string ImagePath { get; set; }

        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Час")]
        [DisplayFormat(DataFormatString = "{0:T}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }

        [Display(Name = "Ціна")]
        [Column(TypeName = "money")]
        public float Price { get; set; }
    }
}
