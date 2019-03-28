using NetworkShaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace NetworkShaker.ViewModels
{
    class LogViewModel
    {
        public LogViewModel()
        {
            Log = new ObservableCollection<MulticastMessage>();

            foreach (string MessageType in typeof(ShakeType).GetEnumNames())
            {
                MessagingCenter.Subscribe<object, MulticastMessage>(this, MessageType, LogMessage);
            }
        }

        private void LogMessage(object sender, MulticastMessage msg)
        {
            Log.Add(msg);
        }

        public ObservableCollection<MulticastMessage> Log { get; set; }
    }
}
