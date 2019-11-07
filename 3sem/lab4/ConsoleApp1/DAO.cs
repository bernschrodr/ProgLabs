namespace ConsoleApp1
{
    class DAO
    {
        IWorker Worker { get; }
        public DAO()
        {
            switch (Settings.Default.WorkerType)
            {
                case "CSV":
                    Worker = new CsvWorker();
                    break;

                case "DB":
                    Worker = new DatabaseWorker();
                    break;
            }
        }
    }
}
