using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Shake4Quake.Models
{
    class ChatAction : IShakeAction
    {
        public string Sender => DeviceInfo.Name;
        public string Name => "Chat";
        public string Icon => "chat";
        public void InvokeAction(string data = null)
        {
            var msg = new MulticastMessage(MessageType.Vibrate, data);
            MessagingCenter.Send<IShakeAction, MulticastMessage>(this, "Send", msg);
        }
    }
}
