using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VideoMotionApp.DependencyService;
using VideoMotionApp.iOS.DependencyService;

[assembly: Xamarin.Forms.Dependency(typeof(ImageOverlayService))]
namespace VideoMotionApp.iOS.DependencyService
{
    public class ImageOverlayService : IPhotoOverlay
    {
        public object GetImageOverlay()
        {
            var imageView = new UIImageView(UIImage.FromBundle("iconOverlay.svg"));
            imageView.ContentMode = UIViewContentMode.ScaleAspectFit;

            var screen = UIScreen.MainScreen.Bounds;
            imageView.Frame = screen;
            return imageView;
        }
    }
}