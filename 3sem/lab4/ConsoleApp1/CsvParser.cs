using System;
using System.IO;
using CsvHelper;
using System.Collections;

namespace ConsoleApp1
{
    class CsvParser
    {
        IEnumerable ParseShops(StreamReader pathCsv)
        {
            using CsvReader csvReader = new CsvReader(pathCsv);
            csvReader.Configuration.Delimiter = ",";
            IEnumerable programmingLanguages = csvReader.GetRecords<Shop>();
            return programmingLanguages;
        }

        IEnumerable ParseProducts(StreamReader pathCsv)
        {
            string line;
            while((line = pathCsv.ReadLine()) != null)
            {
                string[] columns = line.Split(',');
                string type = columns[0];
                string name = columns[1];
                if((columns.Length - 2) % 3 != 0)
                {
                    Console.WriteLine("Bad csv Products file");
                }
                for(var i = 2; i < columns.Length; i+=3)
                {
                    
                }

            }
        }
    }
}
