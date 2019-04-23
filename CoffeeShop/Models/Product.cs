using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int ProductType { get; set; }
        public string Description { get; set; }
        public decimal Price = 0.00M;
        //might have to change this
        public byte[] Image { get; set; }
    }
}
