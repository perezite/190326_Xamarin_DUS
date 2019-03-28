﻿using Shake4Quake.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Shake4Quake.ViewModels
{
    class ShakeViewModel
    {
        public ShakeViewModel()
        {
            service = new MulticastService();
            service.StartService();
            Accelerometer.ShakeDetected += ShakeDetected;

            if (Accelerometer.IsMonitoring)
                Accelerometer.Stop();
            else
                Accelerometer.Start(SensorSpeed.UI);
        }
        private readonly MulticastService service;
        private void ShakeDetected(object sender, EventArgs e)
        {
            service.SendMessage("vibrate");
        }
    }
}
