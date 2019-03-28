using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NetworkShaker.Models
{
    class VibrateShakeItem : BaseShakeItem
    {
        public VibrateShakeItem() :base(ShakeType.Vibrate)
        {
            Active = false;
        }
        public override string Title => "Vibrate";
        public override string Description => "Shake your phone to let every phone vibrate !";
        public override string IconID => "md-vibration";
        public override string AdditionalData { get; set; }
        public override bool AdditionalDataNeeded => false;

        public override void InvokeAction(object sender, MulticastMessage msg)
        {
            if (!Active) return;
            Vibration.Vibrate();
        }
    }
}
