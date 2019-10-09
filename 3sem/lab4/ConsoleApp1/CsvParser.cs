using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class CsvParser
    {
        Dictionary<int, Shop> ParseShops(StreamReader pathCsv)
        {
            Dictionary<int, Shop> shops = new Dictionary<int, Shop>();
            string line;
            while ((line = pathCsv.ReadLine()) != null)
            {
                string[] columns = line.Split(',');
                if (columns.Length != 2)
                {
                    Console.WriteLine("Bad csv Products file");
                    continue;
                }
                int shopId;
                string name = columns[1];
                if(int.TryParse(columns[0], out shopId))
                {

                }
                Shop shop = new Shop(shopId, columns[1]);
                shops.Add(shopId, shop);
            }
            return shops;

        List<Product> ParseProducts(StreamReader pathCsv, Dictionary<int, Shop> shops)
        {
            string line;
            List<Product> csvDatas = new List<Product>();
            while ((line = pathCsv.ReadLine()) != null)
            {
                
                string[] columns = line.Split(',');
                if ((columns.Length - 2) % 3 != 0)
                {
                    Console.WriteLine("Bad csv Products file");
                    continue;
                }
                Product data = new Product();
                
                data.type = columns[0];
                data.name = columns[1];
                            
                for(var i = 2; i < columns.Length; i+=3)
                {
                    WhereSell innerData = new WhereSell();
                    innerData.shopId = columns[i];
                    innerData.count = columns[i + 1];
                    innerData.cost = columns[i + 2];
                    data.whereSell.Add(innerData);
                }
                csvDatas.Add(data);
            }
            return csvDatas;

        }
    }
}
