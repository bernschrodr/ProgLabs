using System;
using System.Threading;

namespace exam
{
    public class HTTPServer
    {
        static void Main(string[] args)
        {
            int maxThreadsCount = Environment.ProcessorCount * 4;
            ThreadPool.SetMaxThreads(maxThreadsCount, maxThreadsCount);
            ThreadPool.SetMinThreads(2, 2);
            var server = new Server(80);
        }
    }
}