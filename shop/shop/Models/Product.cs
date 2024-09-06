using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using shop.ViewModels;

namespace shop.Models
{
    public class Product 
    {
        public int ID { get; set; }
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Название товара должно быть быть от 2 до 30 символов")]
        public string Title { get; set; }
        public double Price { get; set; } = default;
        public double Rating { get; set; } = default;
        public string Description { get; set; } = string.Empty;
        public virtual Category Category { get; set; }
        public string ImageLink { get; set; } = string.Empty;



    }
}
