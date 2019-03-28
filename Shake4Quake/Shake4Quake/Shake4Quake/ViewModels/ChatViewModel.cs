using Shake4Quake.Models;
using Shake4Quake.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Shake4Quake.ViewModels
{
    class ChatViewModel
    {
        public ChatViewModel()
        {
            Chatlog = new ObservableCollection<MulticastMessage>();
            MessagingCenter.Subscribe<MulticastService, MulticastMessage>(this, MessageType.Chat.ToString(), LogMessage);
        }

        private void LogMessage(MulticastService arg1, MulticastMessage arg2)
        {
            Chatlog.Add(arg2);
        }

        public ObservableCollection<MulticastMessage> Chatlog { get; set; }
    }
}
