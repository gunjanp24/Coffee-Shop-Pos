namespace CoffeeShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int ProductType { get; set; }
        public string Description { get; set; }
        public decimal Price = 0.00M;
        public byte[] Image { get; set; }
    }
}
