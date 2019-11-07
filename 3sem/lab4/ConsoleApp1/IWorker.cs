using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IWorker
    {
        public void CreateShop(int id, string name);
        public void CreateProduct(string name, double price, int count, int shopId);
        public void CreateProduct(string name, double price, int count, List<Shop> shops);
        public void RestockProducts(List<Product> products);
        public Shop FindLowestPriceShop(Dictionary<string, int> products);
        public Dictionary<int, Product> GetHowMuchCanBuy(int shopId, double money);
        public double BuyProduct(string name, int count);
        public double BuyProduct(string name, int count, int shopId);
        public Shop FindLowestPriceShop(string name);
        public List<Product> GetSortedProductList(string name);

    }
}
