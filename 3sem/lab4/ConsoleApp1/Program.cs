using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            StreamReader shopsFile = new StreamReader("shops.csv");
            StreamReader productsFile = new StreamReader("products.csv");
            //DAO dao = new DAO(shopsFile, productsFile);
            DatabaseWorker dao = new DatabaseWorker();
            dao.CreateShop(100, "Перекресток");
            //dao.CreateProduct("Молоко Домик в Деревне", 72, 185, 100);
            //dao.CreateProduct("Телевизор PHILIPS", 22000, 5, 1);
            //dao.CreateProduct("Телевизор PHILIPS", 23000, 5, 100);
            Console.WriteLine(dao.BuyProduct("Молоко Домик в Деревне", 15));
            var howMuch = dao.GetHowMuchCanBuy(1, 5000);
            Dictionary<string, int> buyList = new Dictionary<string, int>
            {
                { "Шоколад ‘Аленка’", 3 },
                { "Телевизор PHILIPS", 2 },
                {"Шоколад 'Alpen Gold'", 2}
            };

            var lowestPriceShop = dao.FindLowestPriceShop(buyList);

            shopsFile.Close();
            productsFile.Close();
        }
    }
}
