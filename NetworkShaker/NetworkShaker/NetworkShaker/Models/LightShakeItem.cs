using NetworkShaker.Models.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NetworkShaker.Models
{
    class LightShakeItem : BaseShakeItem
    {
        public LightShakeItem() : base(ShakeType.Light)
        {
            Active = false;
        }
        public override string Title => "Flashlight";
        public override string Description => "Shake your phone to turn every flashlight on or off. Toggle with the text 'On' or 'Off' !";
        public override string IconID => "md-highlight";
        public override string AdditionalData { get; set; }
        public override bool AdditionalDataNeeded => true;

        public override void InvokeAction(object sender, MulticastMessage msg)
        {
            if (!Active) return;

            if (msg.Data == "On")
                Flashlight.TurnOnAsync();
            else if(msg.Data =="Off")
                Flashlight.TurnOffAsync();
        }
    }
}
