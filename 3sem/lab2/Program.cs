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
            }
            catch (System.Exception e)
            {
                Console.WriteLine("File error: ");
                Console.WriteLine(e.Message);
            }


        }
    }
}
