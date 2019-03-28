using NetworkShaker.Models.Interfaces;
using Xamarin.Forms;

namespace NetworkShaker.Models
{
    abstract class BaseShakeItem : IShakeItem
    {
        public BaseShakeItem(ShakeType ShakeType)
        {
            this.ShakeType = ShakeType;
        }
        public ShakeType ShakeType { get; }

        public abstract string Title { get; }

        public abstract string Description { get; }

        public abstract string IconID { get; }

        public abstract string AdditionalData { get; set; }

        public abstract bool AdditionalDataNeeded { get; }

        private bool active;
        public bool Active
        {
            get => active;
            set
            {
                active = value;
                if (active)
                    MessagingCenter.Subscribe<object, MulticastMessage>(this, ShakeType.ToString(), InvokeAction);
                else
                    MessagingCenter.Unsubscribe<object, MulticastMessage>(this, ShakeType.ToString());
            }
        }
        public abstract void InvokeAction(object sender, MulticastMessage msg);
        public abstract void TriggerAction();
    }
}
