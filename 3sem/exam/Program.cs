using System;
using System.Threading;


namespace HTTPServer
{

public class HTTPServer{
        static void Main(string[] args)
        {
            // Определим нужное максимальное количество потоков
            // Пусть будет по 4 на каждый процессор
            int MaxThreadsCount = Environment.ProcessorCount * 4;
            // Установим максимальное количество рабочих потоков
            ThreadPool.SetMaxThreads(1, 1);
            // Установим минимальное количество рабочих потоков
            ThreadPool.SetMinThreads(1, 1);
            // Создадим новый сервер на порту 80
            new Server(80);
        }
    }
}
