using System;
using System.IO;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                StreamReader sr = new StreamReader("input.txt");
                Catalogue catalog = new Catalogue(sr);
                catalog.Search(new SearchOptions("STARGAZING"));
                catalog.Search(new SearchOptions("Believer"));
                catalog.Search(new SearchOptions("imagine dragons"));
                catalog.Search(new SearchOptions(name: "Believer",genre: new Rock()));
                catalog.Search(new SearchOptions("sda"));
                catalog.Search(new SearchOptions(genre: new Rock()));
            }
            catch (System.Exception e)
            {
                Console.WriteLine("File error: ");
                Console.WriteLine(e.Message);
            }


        }
    }
}
