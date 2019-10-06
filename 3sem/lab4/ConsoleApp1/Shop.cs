using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        List<Product> Products {get;} = new List<Product>();
        
    }
}