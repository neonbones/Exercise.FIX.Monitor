using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monitor.Models
{
    public class Site
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить \"Сайт\"")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить \"Обновление\"")]
        public int RefreshTime { get; set; }
    }
}
