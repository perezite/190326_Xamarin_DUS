using Newtonsoft.Json;
using Shake4Quake.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Shake4Quake.Services
{
    public class MulticastService
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
            MessagingCenter.Subscribe<IShakeAction, MulticastMessage>(this, "Send", SendJSON);
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
        public void SendJSON(IShakeAction sender, MulticastMessage data)
        {
            if (IsRunning)
            {
                var json = JsonConvert.SerializeObject(data);
                var bytes = Encoding.Default.GetBytes(json);
                client.Send(bytes, bytes.Length, remoteep);
            }
        }
        private void Listen()
        {
            while (true)
            {
                if (cts.Token.IsCancellationRequested)
                    break;

                byte[] data = client.Receive(ref localEp);
                string json = Encoding.Default.GetString(data, 0, data.Length);
                MulticastMessage msg = JsonConvert.DeserializeObject<MulticastMessage>(json);
                MessagingCenter.Send(this, msg.Type.ToString(), msg);
            }
        }
    }
}
