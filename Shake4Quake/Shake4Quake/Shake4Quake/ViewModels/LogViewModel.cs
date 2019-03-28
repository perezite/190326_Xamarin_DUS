using Shake4Quake.Models;
using Shake4Quake.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Shake4Quake.ViewModels
{
    class LogViewModel
    {
        public LogViewModel()
        {
            Log = new ObservableCollection<MulticastMessage>();
            MessagingCenter.Subscribe<MulticastService, MulticastMessage>(this, MessageType.Vibrate.ToString(), LogMessage);
            MessagingCenter.Subscribe<MulticastService, MulticastMessage>(this, MessageType.Light.ToString(), LogMessage);
            MessagingCenter.Subscribe<MulticastService, MulticastMessage>(this, MessageType.Text2Speech.ToString(), LogMessage);
        }

        private void LogMessage(MulticastService arg1, MulticastMessage arg2)
        {
            Log.Add(arg2);
        }

        public ObservableCollection<MulticastMessage> Log { get; set; }
    }
}
