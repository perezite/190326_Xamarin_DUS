using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl;
using UserControl.UWP;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomButton),typeof(CustomButtonRenderer))]
namespace UserControl.UWP
{
    class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            Control.Background = new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop{Offset=0,Color=Windows.UI.Colors.DarkTurquoise},
                    new GradientStop{Offset=0.5,Color=Windows.UI.Colors.LightCoral},
                    new GradientStop{Offset=1,Color=Windows.UI.Colors.SlateBlue},
                }
            };
        }
    }
}
