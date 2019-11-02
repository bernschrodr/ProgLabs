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
            DAO dao = new DAO();
            dao.CreateShop(100, "Перекресток");
            //dao.CreateProduct("Молоко Домик в Деревне", 72, 185, 100);
            Console.WriteLine( dao.BuyProduct("Молоко Домик в Деревне", 15));
            var howMuch = dao.GetHowMuchCanBuy(1,5000);
            Dictionary<string, int> buyList = new Dictionary<string, int>();
            buyList.Add("Молоко Домик в Деревне", 3);
            var temp = dao.FindLowestPrice(buyList);


            shopsFile.Close();
            productsFile.Close();

/*

            var shops = db.shops;
            console.writeline("shops: ");
            foreach (Shop shop in shops)
            {
                console.writeline(shop.name);
            }*/
        }
    }
}
