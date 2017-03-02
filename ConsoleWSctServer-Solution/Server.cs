using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleWSctServer_Solution
{
    class Server
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Server window]");

            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            sck.Bind(new IPEndPoint(0, 1994));
           sck.Listen(0);

            Socket accept = sck.Accept();

            byte[] buffer = Encoding.ASCII.GetBytes("Hello CLient!");
            accept.Send(buffer, 0, buffer.Length, 0);

            buffer = new byte[255];

            int receive = accept.Receive(buffer,0, buffer.Length, 0);

            Array.Resize(ref buffer, receive);

            Console.WriteLine("Received: {0}", Encoding.ASCII.GetString(buffer));

            sck.Shutdown(SocketShutdown.Both);

            Console.ReadLine();
        }
    }
}