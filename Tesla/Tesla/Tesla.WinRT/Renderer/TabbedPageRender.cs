using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.WinRT.Renderer;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(TabbedPageRender))]
namespace Tesla.WinRT.Renderer
{
    public class TabbedPageRender : TabbedPageRenderer
    {

        public TabbedPageRender()
        {
            this.ElementChanged += (s, e) =>
            {
                Control.Background = new ImageBrush()
                {
                    AlignmentX = AlignmentX.Center,
                    AlignmentY = AlignmentY.Center,
                    ImageSource = new BitmapImage(new Uri("ms-appx:///Images/background.png", UriKind.Absolute)),
                    Stretch = Stretch.None
                };
            };
        }

    }
}
