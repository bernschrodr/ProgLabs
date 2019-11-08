
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            switch (Settings.Default.WorkerType)
            {
                case "CSV":
                    ConsoleApp1.Tests.CsvTest.Start();
                    break;
                case "DB":
                    ConsoleApp1.Tests.DbTest.Start();
                    break;
                
            }
        }
    }
}
