using NetworkShaker.Models.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetworkShaker.Models
{
    class ChatShakeItem : BaseShakeItem
    {
        public ChatShakeItem() : base(ShakeType.Chat)
        {
            Active = false;
        }
        public override string Title => "Chat";
        public override string Description => "Shake your phone to send your message to every phone !";
        public override string IconID => "md-chat";
        public override string AdditionalData { get; set; }
        public override bool AdditionalDataNeeded => true;

        public override void InvokeAction(object sender, MulticastMessage msg)
        {
            if (!Active || string.IsNullOrWhiteSpace(msg.Data)) return;

            Application.Current.MainPage.DisplayAlert("Chatnachricht", msg.Data, "Ok");
        }
    }
}
