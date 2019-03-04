using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_demo.Services
{
    public interface IImageProvider
    {
        string GetImagePath(string imageName);
    }
}
