using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace NetworkShaker.Models
{
    public enum ShakeType { Vibrate, Text2Speech, Light, Chat }
    public class MulticastMessage
    {
        public MulticastMessage(ShakeType Type, string Data = null, string Sender = null)
        {
            this.Type = Type;
            this.Data = Data;
            this.Sender = Sender ?? DeviceInfo.Name;
        }

        public ShakeType Type { get; set; }
        public string Data { get; set; }
        public string Sender { get; set; }
    }
}
