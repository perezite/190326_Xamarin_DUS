using Xamarin.Essentials;
using Xamarin.Forms;

namespace Shake4Quake.Models
{
    class VibrateAction : IShakeAction
    {
        public string Sender => DeviceInfo.Name;
        public string Name => "Vibrate";
        public string Icon => "vibration";
        public void InvokeAction(string data = null)
        {
            var msg = new MulticastMessage(MessageType.Vibrate, data);
            MessagingCenter.Send<IShakeAction,MulticastMessage>(this, "Send", msg);
        }
    }
}
