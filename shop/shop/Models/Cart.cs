using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Models
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }
        public Product Product { get; set; }
        public Users User { get; set; }
        public int Count { get; set; }
        public double SumPrice { get; set; }
    }
}
