using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Client window]");

            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1994);
            sck.Connect(endPoint);

            Console.Write("Enter message: ");
            string message = Console.ReadLine();
            byte[] msgBuffer = Encoding.ASCII.GetBytes(message);
            sck.Send(msgBuffer, 0, msgBuffer.Length, 0);

            byte[] buffer = new byte[255];
            int receive = sck.Receive(buffer, 0, buffer.Length, 0);

            Array.Resize(ref buffer, receive);

            Console.WriteLine("Received: {0}", Encoding.ASCII.GetString(buffer));

            sck.Shutdown(SocketShutdown.Both);

            Console.ReadLine();
        }
    }
}