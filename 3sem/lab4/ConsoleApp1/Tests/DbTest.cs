using System;
using System.Collections.Generic;

namespace ConsoleApp1.Tests
{
    static class DbTest
    {
        public static void Start()
        {
            DAO dao = new DAO();
            var data = dao.Data;

            data.CreateShop(100, "Перекресток");
            //data.CreateProduct("Молоко Домик в Деревне", 72, 185, 100);
            //data.CreateProduct("Телевизор PHILIPS", 22000, 5, 1);
            //data.CreateProduct("Телевизор PHILIPS", 23000, 5, 100);
            Console.WriteLine(data.BuyOneProduct("Молоко Домик в Деревне", 15));
            var howMuch = data.GetHowMuchCanBuy(1, 5000);

            Dictionary<string, int> buyList = new Dictionary<string, int>();
            var lowestPriceShop = data.FindLowestPriceShop(buyList);
        }
    }
}
