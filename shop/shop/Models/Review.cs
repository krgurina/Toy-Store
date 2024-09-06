using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public Users User { get; set; }
        public Product Product { get; set; }
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Отзыв должен быть быть от 2 до 300 символов")]
        public string ReviewContent { get; set; } = string.Empty;
        public int UserRating { get; set; } = default;
    }
}
