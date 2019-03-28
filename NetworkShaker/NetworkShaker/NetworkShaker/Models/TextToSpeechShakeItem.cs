using NetworkShaker.Models.Interfaces;
using System;
using System.Threading.Tasks;

namespace NetworkShaker.Models
{
    class TextToSpeechShakeItem //: IShakeItem
    {
        public string Title => "Text to Speech";
        public string Description => "Shake your phone to let every phone say your Text !";
        public string IconID => "md-record-voice-over";
        public string AdditionalData { get; set; }
        public bool AdditionalDataNeeded => true;
        public bool Active { get; set; }



        public async Task InvokeAction()
        {
            throw new NotImplementedException();
        }
    }
}
