using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderState { get; set; } = string.Empty;
        public Users? User { get; set; }
        public Product? Product { get; set; }
        public int Count { get; set; }
        public double SumPrice { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Cart { get; set; } = string.Empty;


    }
}
