
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            ConsoleApp1.Tests.CsvTest.Start();
            ConsoleApp1.Tests.DbTest.Start();
            return;
            switch (Settings.Default.WorkerType)
            {
                case "CSV":
                    ConsoleApp1.Tests.CsvTest.Start();
                    break;
                case "DB":
                    ConsoleApp1.Tests.DbTest.Start();
                    break;
                default:
                    return;
            }
        }
    }
}
