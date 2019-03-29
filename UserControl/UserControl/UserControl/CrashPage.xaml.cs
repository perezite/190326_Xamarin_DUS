using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CrashPage : ContentPage
	{
		public CrashPage ()
		{
			InitializeComponent ();
		}

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            Analytics.TrackEvent("EnterCrashPage");
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            Analytics.TrackEvent("LeaveCrashPage");
        }

        private void ButtonDivideByZero_Clicked(object sender, EventArgs e)
        {
            try
            {
                throw new DivideByZeroException();
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }
        }

        private void ButtonFormat_Clicked(object sender, EventArgs e)
        {
            try
            {
                throw new FormatException();
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }
        }

        private void ButtonStackOverflow_Clicked(object sender, EventArgs e)
        {
            try
            {
                throw new StackOverflowException();
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }
        }

        private void ButtonKillApp_Clicked(object sender, EventArgs e)
        {
            Crashes.GenerateTestCrash(); 
        }
    }
}