using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using xamarin_demo.iOS;
using xamarin_demo.Services;

[assembly: Xamarin.Forms.Dependency(typeof(ImageProvider_iOS))]
namespace xamarin_demo.iOS
{
    public class ImageProvider_iOS : IImageProvider
    {
        public string GetImagePath(string imageName)
        {
            return Path.Combine(AppConstants.Strings.IOS_IMAGE_FOLDER, imageName);
        }
    }
}