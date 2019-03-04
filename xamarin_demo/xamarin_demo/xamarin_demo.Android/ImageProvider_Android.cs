using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using xamarin_demo.Services;

[assembly: Xamarin.Forms.Dependency(typeof(xamarin_demo.Droid.ImageProvider_Android))]
namespace xamarin_demo.Droid
{
    public class ImageProvider_Android : IImageProvider
    {
        public string GetImagePath(string imageName)
        {
            return imageName;
        }
    }
}