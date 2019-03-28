using NetworkShaker.Models.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NetworkShaker.Models
{
    class TextToSpeechShakeItem : BaseShakeItem
    {
        public TextToSpeechShakeItem() : base(ShakeType.Text2Speech)
        {
            Active = false;
        }

        public override string Title => "Text to Speech";
        public override string Description => "Shake your phone to let every phone say your Text !";
        public override string IconID => "md-record-voice-over";
        public override string AdditionalData { get; set; }
        public override bool AdditionalDataNeeded => true;

        public override void InvokeAction(object sender, MulticastMessage msg)
        {
            if (!Active || string.IsNullOrWhiteSpace(msg.Data)) return;

            TextToSpeech.SpeakAsync(msg.Data);
        }
    }
}
