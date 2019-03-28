using NetworkShaker.Models.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetworkShaker.Models
{
    class ChatShakeItem // : IShakeItem
    {
        public string Title => "Chat";
        public string Description => "Shake your phone to send your message to every phone !";
        public string IconID => "md-chat";
        public string AdditionalData { get; set; }
        public bool AdditionalDataNeeded => true;
        public bool Active { get; set; }


        public async Task InvokeAction()
        {
            if (!Active) return;
            MulticastMessage msg = new MulticastMessage(ShakeType.Chat, AdditionalDataNeeded ? AdditionalData : null);
           //  MessagingCenter.Send<IShakeItem, MulticastMessage>(this, "Send", msg);
        }
    }
}
