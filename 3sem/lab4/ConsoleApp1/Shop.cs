using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        List<Product> Products {get;} = new List<Product>();
        
        public Shop(int ShopId, string Name)
        {
            this.ShopId = ShopId;
            this.Name = Name;
        }
    }
}