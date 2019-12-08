using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
using System.IO;

namespace exam
{
    public class Server
    {
        TcpListener _listener;
        public Server(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();

            while (true)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), _listener.AcceptTcpClient());
            }
        }

        static void ClientThread(Object stateInfo)
        {
            var client = new Client((TcpClient) stateInfo);
        }

        ~Server()
        {
            _listener?.Stop();
        }
    }
}