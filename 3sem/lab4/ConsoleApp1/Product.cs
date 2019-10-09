using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public List<int> ShopId { get; set; } = new List<int>();
        public List<Shop> Shop { get; } = new List<Shop>();
    }
}