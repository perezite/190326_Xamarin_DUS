using NetworkShaker.Models;
using NetworkShaker.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NetworkShaker.ViewModels
{
    class ShakeViewModel : BaseViewModel
    {
        public ShakeViewModel()
        {
            ShakeItems = AppDomain.CurrentDomain.GetAssemblies()
                           .SelectMany(assembly => assembly.GetTypes())
                           .Where(type => typeof(BaseShakeItem).IsAssignableFrom(type) &&
                                          type.IsInterface == false &&
                                          type.IsAbstract == false)
                           .Select(type => (IShakeItem)Activator.CreateInstance(type))
                           .ToList();

            Accelerometer.ShakeDetected += ShakeDetected;
            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();
            else
                Accelerometer.Start(SensorSpeed.UI);
        }

        public List<IShakeItem> ShakeItems { get; set; }
        public int TotalShakeItems => ShakeItems.Count();

        private int selectedShakeItemIndex;
        public int SelectedShakeItemIndex
        {
            get => selectedShakeItemIndex;
            set => SetProperty(ref selectedShakeItemIndex, value);
        }

        private void ShakeDetected(object sender, EventArgs e)
        {
            ShakeItems[SelectedShakeItemIndex].TriggerAction();
        }
    }
}
