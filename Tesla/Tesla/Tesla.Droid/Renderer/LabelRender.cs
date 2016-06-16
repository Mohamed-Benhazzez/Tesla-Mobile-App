using Android.Views;
using System.Linq;
using Tesla.Droid.Renderer;
using Tesla.Gestures;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(LabelRender))]
namespace Tesla.Droid.Renderer
{
    public class LabelRender: LabelRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                if (!e.NewElement.GestureRecognizers.Any())
                    return;

                if (e.NewElement.GestureRecognizers.Any(x => x.GetType() == typeof(PressedGestureRecognizer)
                                                            || x.GetType() == typeof(ReleasedGestureRecognizer)))
                    Control.Touch += Control_Touch;

            }
        }

        private void Control_Touch(object sender, TouchEventArgs e)
        {
            switch (e.Event.Action)
            {
                case MotionEventActions.Down:
                    foreach (var recognizer in this.Element.GestureRecognizers.Where(x => x.GetType() == typeof(PressedGestureRecognizer)))
                    {
                        var gesture = recognizer as PressedGestureRecognizer;
                        if (gesture != null)
                            if (gesture.Command != null)
                                gesture.Command.Execute(gesture.CommandParameter);
                    }
                    break;

                case MotionEventActions.Up:
                    foreach (var recognizer in this.Element.GestureRecognizers.Where(x => x.GetType() == typeof(ReleasedGestureRecognizer)))
                    {
                        var gesture = recognizer as ReleasedGestureRecognizer;
                        if (gesture != null)
                            if (gesture.Command != null)
                                gesture.Command.Execute(gesture.CommandParameter);
                    }
                    break;

                default:
                    break;
            }
        }

    }
}