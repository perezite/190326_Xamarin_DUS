using NetworkShaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NetworkShaker.ViewModels
{
    class ChatViewModel : BaseViewModel
    {
        public ChatViewModel()
        {
            Chatlog = new ObservableCollection<MulticastMessage>();
            MessagingCenter.Subscribe<object, MulticastMessage>(this, ShakeType.Chat.ToString(), LogMessage);
            SendChatMessageCommand = new Command(SendChatMessage);
        }

        private void LogMessage(object sender, MulticastMessage msg)
        {
            Chatlog.Add(msg);
        }

        public ObservableCollection<MulticastMessage> Chatlog { get; set; }
        public Command SendChatMessageCommand { get; set; }

        private string chatMessage;
        public string ChatMessage
        {
            get => chatMessage;
            set => SetProperty(ref chatMessage, value);
        }

        private void SendChatMessage(object obj)
        {
            MulticastMessage msg = new MulticastMessage(ShakeType.Chat, ChatMessage);
            MessagingCenter.Send<object, MulticastMessage>(this, ShakeType.Chat.ToString(), msg);  // self
            MessagingCenter.Send<object, MulticastMessage>(this, "SendMessage", msg);   // all
            ChatMessage = string.Empty;
        }
    }
}
