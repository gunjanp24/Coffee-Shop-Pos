namespace CoffeeShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int ProductType { get; set; }
        public string Description { get; set; }
        public double Price;
        public byte[] Image { get; set; }
    }
}
