using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using Database db = new Database();
            Shop shop1 = new Shop { Name = "Wallmart" };
            db.Shops.Add(shop1);
            db.SaveChanges();

            var shops = db.Shops;
            Console.WriteLine("Shops: ");
            foreach (Shop shop in shops)
            {
                Console.WriteLine(shop.Name);
            }
        }
    }
}
