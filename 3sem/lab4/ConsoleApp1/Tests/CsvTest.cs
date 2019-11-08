using System.Collections.Generic;

namespace ConsoleApp1.Tests
{
    static class CsvTest
    {
        public static void Start()
        {
            DAO dao = new DAO();
            var data = dao.Data;

            Dictionary<string, (int count, int shopId)> buyList = new Dictionary<string, (int count, int shopId)>
                        {
                            { "Шоколад ‘Аленка’", (3,1) },
                            { "Телевизор PHILIPS", (1,2) },
                        };

            Dictionary<string, int> secondBuyList = new Dictionary<string, int>
                        {
                            { "Шоколад ‘Аленка’", 3 },
                            { "Телевизор PdPS", 1 },
                        };
            data.CreateProduct("dd", 12, 23, 1);
            data.BuyListProduct(buyList);
            data.FindLowestPriceShop("Шоколад ‘Аленка’");
            var howMuch = data.GetHowMuchCanBuy(1, 4000);
            var lowestPriceShop = data.FindLowestPriceShop(secondBuyList);
        }
    }
}
