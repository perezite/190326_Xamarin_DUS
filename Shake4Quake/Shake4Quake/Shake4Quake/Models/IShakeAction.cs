namespace Shake4Quake.Models
{
    public interface IShakeAction
    {
        string Icon {get;}
        string Name {get;}
        string Sender {get;}

        void InvokeAction(string data);
    }
}