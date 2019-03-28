using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetworkShaker.Models.Interfaces
{
    interface IShakeItem
    {
        string Title { get; }
        ShakeType ShakeType { get; }
        string Description { get; }
        string IconID { get; }
        string AdditionalData { get; set; }
        bool AdditionalDataNeeded { get; }
        bool Active { get; set; }

        void TriggerAction();
        void InvokeAction(object sender, MulticastMessage msg);
    }
}
