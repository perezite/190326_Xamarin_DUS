using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Shake4Quake.Services
{
    class MulticastService
    {
        public MulticastService()
        {
            client = new UdpClient();
            client.ExclusiveAddressUse = false;
            localEp = new IPEndPoint(IPAddress.Any, 1234);

            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.ExclusiveAddressUse = false;

            client.Client.Bind(localEp);

            IPAddress multicastaddress = IPAddress.Parse("224.0.0.99");
            client.JoinMulticastGroup(multicastaddress);
            remoteep = new IPEndPoint(multicastaddress, 1234);


            cts = new CancellationTokenSource();
        }
        private CancellationTokenSource cts;
        private Task listener;

        private UdpClient client;
        private IPEndPoint localEp;
        private IPEndPoint remoteep;

        public bool IsRunning { get; set; }

        public void StartService()
        {
            if (IsRunning)
                return;
            listener = Task.Run(new Action(Listen));
            IsRunning = true;
        }
        public void StoppService()
        {
            if (IsRunning)
            {
                cts.Cancel();
                IsRunning = false;
            }
        }
        public void SendMessage(string message)
        {
            if (IsRunning)
            {
                var data = Encoding.Default.GetBytes(message);
                client.Send(data, data.Length, remoteep);
            }
        }
        private void Listen()
        {
            while (true)
            {
                if (cts.Token.IsCancellationRequested)
                    break;

                byte[] data = client.Receive(ref localEp);
                string message = Encoding.Default.GetString(data, 0, data.Length);
                if (message == "vibrate")
                    Vibration.Vibrate(1000);
            }

        }
    }
}
