using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string ImageLink { get; set; } = string.Empty;
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Название категории должно быть быть от 2 до 30 символов")]
        public string Name { get; set; } = string.Empty;

        
    }
}
