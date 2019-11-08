using System;
using System.IO;

namespace ConsoleApp1
{
    class DAO
    {
        public IDataWorker Data { get; }
        public DAO()
        {
            switch (Settings.Default.WorkerType)
            {
                case "CSV":
                    using (StreamReader productsPath = new StreamReader(Settings.Default.ProductsPath),
                        shopsPath = new StreamReader(Settings.Default.ShopsPath))
                    {
                        Data = new CsvWorker(productsPath, shopsPath);
                    }
                    break;

                case "DB":
                    Data = new DatabaseWorker();
                    break;
                default:
                    throw new Exception("Wrong Config: 'WorkerType'");
            }
        }
    }
}
