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
                new LightAction(),
                new ChatAction(),
            };
            Accelerometer.ShakeDetected += ShakeDetected;

            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();
            else
                Accelerometer.Start(SensorSpeed.UI);
        }

        private void Text2Speech(MulticastService arg1, MulticastMessage msg)
        {
            if (!Selbsttest && DeviceInfo.Name == msg.Sender)
                return;

            TextToSpeech.SpeakAsync(msg.Data);
        }

        private void Light(MulticastService arg1, MulticastMessage msg)
        {
            if (!Selbsttest && DeviceInfo.Name == msg.Sender)
                return;

            if (msg.Data == "On")
                Flashlight.TurnOnAsync();
            else
                Flashlight.TurnOffAsync();
        }
        private void Vibrate(MulticastService arg1, MulticastMessage msg)
        {
            if (!Selbsttest && DeviceInfo.Name == msg.Sender)
                return;

            Vibration.Vibrate();
        }

        private void ShakeDetected(object sender, EventArgs e)
        {
            SelectedShakeAction?.InvokeAction(string.IsNullOrWhiteSpace(Data) ? SelectedShakeAction.Name : Data);
        }

        public bool Selbsttest { get; set; }
        public string Data { get; set; }
        public IShakeAction SelectedShakeAction { get; set; }
        public List<IShakeAction> ShakeActions { get; set; }

        ~ShakeViewModel()
        {
            MessagingCenter.Unsubscribe<MulticastService, MulticastMessage>(this, MessageType.Vibrate.ToString());
        }
    }
}
