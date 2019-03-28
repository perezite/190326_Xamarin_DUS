using Xamarin.Essentials;
using Xamarin.Forms;

namespace Shake4Quake.Models
{
    class Text2SpeechAction : IShakeAction
    {
        public string Sender => DeviceInfo.Name;
        public string Name => "Text2Speech";
        public string Icon => "record_voice_over";
        public void InvokeAction(string data = null)
        {
            var msg = new MulticastMessage(MessageType.Text2Speech, data);
            MessagingCenter.Send<IShakeAction, MulticastMessage>(this, "Send", msg);
        }
    }
}
