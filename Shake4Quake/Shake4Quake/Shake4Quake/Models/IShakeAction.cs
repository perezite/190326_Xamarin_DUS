namespace Shake4Quake.Models
{
    interface IShakeAction
    {
        string Icon {get;}
        string Name {get;}
        string Sender {get;}

        void InvokeAction(string data);
    }
}