using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using VideoMotionApp.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Entry), typeof(ExtEntryCustomRenderer))]
[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.Button), typeof(ButtonCustomRenderer))]
namespace VideoMotionApp.Droid.CustomRenderer
{
#pragma warning disable CS0618 // Type or member is obsolete

    public class ExtEntryCustomRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            GradientDrawable gd = new GradientDrawable();
            gd.SetCornerRadius(10);
            gd.SetStroke(2, Android.Graphics.Color.ParseColor("#D9D9D9"));
            gd.SetColor(Android.Graphics.Color.ParseColor("#FFFFFF"));
            this.Control.Background = gd;
            this.Control.Gravity = Android.Views.GravityFlags.CenterVertical;
            this.Control.SetPadding(20, 0, 20, 0);
        }
    }

    public class ButtonCustomRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            var textView1 = (TextView)this.Control;
            this.Control.SetAllCaps(false);
        }
    }

#pragma warning restore CS0618 // Type or member is obsolete
}