using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Shake4Quake.Models
{
    enum MessageType {Vibrate,Text2Speech,Light}
    class MulticastMessage
    {
        public MulticastMessage(MessageType Type,string Data = null,string Sender = null)
        {
            this.Type = Type;
            this.Data = Data;
            this.Sender = Sender ?? DeviceInfo.Name;
        }

        public MessageType Type { get; set; }
        public string Data { get; set; }
        public string Sender { get; set; }
    }
}
