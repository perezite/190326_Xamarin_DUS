using NetworkShaker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetworkShaker.Services
{
    class MulticastService
    {
        private const int PORT = 9999;
        private const string IPADDRESS = "230.0.0.30";

        public MulticastService()
        {
            client = new UdpClient();
            localEndpoint = new IPEndPoint(IPAddress.Any, PORT);
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.ExclusiveAddressUse = false;
            client.Client.Bind(localEndpoint);

            IPAddress multicastaddress = IPAddress.Parse(IPADDRESS);
            remoteEndpoint = new IPEndPoint(multicastaddress, PORT);
            client.JoinMulticastGroup(multicastaddress);
            cts = new CancellationTokenSource();

            MessagingCenter.Subscribe<object, MulticastMessage>(this, "SendMessage", SendMessage);
        }
        private UdpClient client;
        private IPEndPoint localEndpoint;
        private IPEndPoint remoteEndpoint;

        private Task listenerTask;
        private readonly CancellationTokenSource cts;

        public bool IsRunning
        {
            get
            {
                if (listenerTask == null) return false;
                if (listenerTask.IsCompleted || listenerTask.IsFaulted || listenerTask.IsCanceled) return false;

                return true;
            }
        }

        public void StartService()
        {
            if (IsRunning) return;

            listenerTask = Task.Run(() =>
            {
                while (true)
                {
                    byte[] data = client.Receive(ref localEndpoint);
                    string json = Encoding.Default.GetString(data, 0, data.Length);
                    MulticastMessage msg = JsonConvert.DeserializeObject<MulticastMessage>(json);
                    MessagingCenter.Send((object)this, msg.Type.ToString(), msg);
                }
            });
        }
        public void StoppService()
        {
            if (IsRunning)
                cts.Cancel();
        }

        private void SendMessage(object sender, MulticastMessage msg)
        {
            if (!IsRunning) return;

            var bytes = Encoding.Default.GetBytes(JsonConvert.SerializeObject(msg));
            client.Send(bytes, bytes.Length, remoteEndpoint);
        }
    }
}
