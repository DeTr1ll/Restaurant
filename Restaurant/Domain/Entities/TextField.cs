using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class TextField
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; } = "Інформаційна сторінка";

        [Display(Name = "Зміст")]
        public string Text { get; set; } = "Зміст заповнюється адміністратором";


    }
}
