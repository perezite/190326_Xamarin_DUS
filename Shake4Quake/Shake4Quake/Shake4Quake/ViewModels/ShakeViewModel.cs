using Shake4Quake.Models;
using Shake4Quake.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Shake4Quake.ViewModels
{
    class ShakeViewModel
    {
        public ShakeViewModel()
        {
            MessagingCenter.Subscribe<MulticastService, MulticastMessage>(this, MessageType.Vibrate.ToString(), Vibrate);
            MessagingCenter.Subscribe<MulticastService, MulticastMessage>(this, MessageType.Light.ToString(), Light);
            MessagingCenter.Subscribe<MulticastService, MulticastMessage>(this, MessageType.Text2Speech.ToString(), Text2Speech);

            ShakeActions = new List<IShakeAction>
            {
                new VibrateAction(),
                new Text2SpeechAction(),
                new LightAction()
            };
            Accelerometer.ShakeDetected += ShakeDetected;

            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();
            else
                Accelerometer.Start(SensorSpeed.UI);
        }

        private void Text2Speech(MulticastService arg1, MulticastMessage arg2)
        {
            TextToSpeech.SpeakAsync(arg2.Data);
        }

        private void Light(MulticastService arg1, MulticastMessage arg2)
        {
            if(arg2.Data == "On")
                Flashlight.TurnOnAsync();
            else
                Flashlight.TurnOffAsync();
        }

        private void ShakeDetected(object sender, EventArgs e)
        {
            string data = null;
            if (SelectedShakeAction.Name == "Text2Speech")
                data = "Hallo Welt";
            else if (SelectedShakeAction.Name == "Light")
                data = "On";

            //else 
            SelectedShakeAction?.InvokeAction(data);
        }

        public IShakeAction SelectedShakeAction { get; set; }
        public List<IShakeAction> ShakeActions { get; set; }

        private void Vibrate(MulticastService arg1, MulticastMessage arg2)
        {
            Vibration.Vibrate();
        }

        ~ShakeViewModel()
        {
            MessagingCenter.Unsubscribe<MulticastService, MulticastMessage>(this, MessageType.Vibrate.ToString());
        }
    }
}
