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
                StreamReader tracksFile = new StreamReader("input.txt");
                StreamReader genresFile = new StreamReader("genres.txt");
                Catalogue catalog = new Catalogue(tracksFile, genresFile);
                catalog.Search(new SearchOptions(type: CatalogueTypes.album));
                catalog.Search(new SearchOptions("ASTROWORLD"));
                catalog.Search(new SearchOptions("Believer"));
                catalog.Search(new SearchOptions("imagine dragons"));
                catalog.Search(new SearchOptions(name: "Believer",genre: "Rock"));
                catalog.Search(new SearchOptions(year: 2017));
                catalog.Search(new SearchOptions(name: "hip hop", type: CatalogueTypes.genre));
            }
            catch (System.Exception e)
            {
                Console.WriteLine("File error: ");
                Console.WriteLine(e.Message);
            }


        }
    }
}
