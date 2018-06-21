using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class ClientSocket
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(ThreadMethod));
                thread.Start(i);
            }
           

        }
        static void ThreadMethod(object obj)
        {
            TcpClient client = new TcpClient("137.48.185.93", 1234);

            StreamReader sw = new StreamReader(client.GetStream());

            if (client.Connected)
            {
                Console.WriteLine("Connected to Server!");
                while (!sw.EndOfStream)
                {
                    string line = sw.ReadLine();
                    Console.WriteLine("Client " + obj + ": " + line);
                }
            }

            sw.Close();
            client.Close();
        }
    }
}
