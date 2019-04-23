using System;

namespace CoffeeShop.Models
{
    public class Transaction
    {
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TAX { get; set; }
        public double SALES { get; set; }
    }
}
