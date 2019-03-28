using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _consoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient();

            client.ExclusiveAddressUse = false;
            IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 1234);

            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.ExclusiveAddressUse = false;

            client.Client.Bind(localEp);

            IPAddress multicastaddress = IPAddress.Parse("224.0.0.99");
            client.JoinMulticastGroup(multicastaddress);

            IPEndPoint remoteep = new IPEndPoint(multicastaddress, 1234);

            Task.Run(() =>
            {
                while (true)
                {
                    Byte[] data = client.Receive(ref localEp);
                    string strData = Encoding.Unicode.GetString(data);
                    Console.WriteLine(strData);
                }
            });

            byte[] buffer = Encoding.Unicode.GetBytes("vibrate");
            for (int i = 0; i <= 8000; i++)
            {
                client.Send(buffer, buffer.Length, remoteep);
                Thread.Sleep(1000);
                Console.WriteLine("Sent " + i);
            }
            Console.ReadKey();
        }
    }
}