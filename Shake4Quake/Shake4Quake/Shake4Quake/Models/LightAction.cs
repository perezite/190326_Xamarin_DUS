using Plugin.Iconize;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Shake4Quake.Models
{
    class LightAction : IShakeAction
    {
        public string Sender => DeviceInfo.Name;
        public string Name => "Light";
        public string Icon => "md-highlight";
        public void InvokeAction(string data = null)
        {
            var msg = new MulticastMessage(MessageType.Light, data);
            MessagingCenter.Send<IShakeAction, MulticastMessage>(this, "Send", msg);
        }
    }
}
