namespace ConsoleApp1
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}