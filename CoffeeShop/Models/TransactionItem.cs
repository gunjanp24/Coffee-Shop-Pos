using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class TransactionItem
    {
        public int TransactionItemID { get; set; }
        public string TransactionID { get; set; }
        public int ProductID { get; set; }
    }
}
