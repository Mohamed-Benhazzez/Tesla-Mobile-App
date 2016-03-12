using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Gestures;
using Tesla.UWP.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using System.Reflection;

[assembly: ExportRenderer(typeof(Label), typeof(ExtendedLabelRenderer))]
namespace Tesla.UWP.Renderer
{

    public class ExtendedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.PointerPressed += Control_PointerPressed;
                Control.PointerReleased += Control_PointerReleased;
            }
        }

       

        private void Control_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            foreach (var recognizer in this.Element.GestureRecognizers)
            {
                var gesture = recognizer as PressedGestureRecognizer;
                if (gesture != null)
                    if (gesture.Command != null)
                        gesture.Command.Execute(gesture.CommandParameter);
            }
        }

        private void Control_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            foreach (var recognizer in this.Element.GestureRecognizers)
            {
                var gesture = recognizer as ReleasedGestureRecognizer;
                if (gesture != null)
                    if (gesture.Command != null)
                        gesture.Command.Execute(gesture.CommandParameter);
            }
        }
    }
}
