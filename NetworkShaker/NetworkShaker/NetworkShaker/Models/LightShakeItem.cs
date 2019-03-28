using NetworkShaker.Models.Interfaces;
using System;
using System.Threading.Tasks;

namespace NetworkShaker.Models
{
    class LightShakeItem //: IShakeItem
    {
        public string Title => "Flashlight";
        public string Description => "Shake your phone to turn every flashlight on or off. Toggle with the text 'On' or 'Off' !";
        public string IconID => "md-highlight";
        public string AdditionalData { get; set; }
        public bool AdditionalDataNeeded => true;
        public bool Active { get; set; }



        public async Task InvokeAction()
        {
            throw new NotImplementedException();
        }
    }
}
