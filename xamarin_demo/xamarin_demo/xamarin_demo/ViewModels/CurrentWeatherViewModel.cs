using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using xamarin_demo.Data.Api;
using xamarin_demo.Services;

namespace xamarin_demo.ViewModels
{
    public class CurrentWeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IImageProvider _imageProvider;
        private CurrentWeatherInfo _info;

        public CurrentWeatherViewModel(CurrentWeatherInfo info)
        {
            _imageProvider = DependencyService.Get<IImageProvider>();
            _info = info;
        }

        public string Temperature
        {
            get { return string.Format(AppConstants.Strings.CELSIUS_FORMAT,Utilities.KelvinToCelcius(_info.main.temp)); }
        }

        public string City
        {
            get { return _info?.name; }
        }

        public string MainWeatherImage
        {
            get
            {
                if(null == _info)
                {
                    return "clear_sky.png";
                }
                return _imageProvider.GetImagePath(App.Database.GetWeatherIcon(_info.weather.ToList()[0].id));
            }
        }

        public string HumidityImage
        {
            get
            {
                return _imageProvider.GetImagePath(AppConstants.Strings.HUMIDITY_IMAGE);
            }
        }

        public string WindImage
        {
            get
            {
                return _imageProvider.GetImagePath(AppConstants.Strings.WIND_IMAGE);
            }
        }

        public string PressureImage
        {
            get
            {
                return _imageProvider.GetImagePath(AppConstants.Strings.PRESSURE_IMAGE);
            }
        }

        public string SunriseImage
        {
            get
            {
                return _imageProvider.GetImagePath(AppConstants.Strings.SUNRISE_IMAGE);
            }
        }

        public string SunsetImage
        {
            get
            {
                return _imageProvider.GetImagePath(AppConstants.Strings.SUNSET_IMAGE);
            }
        }

        public string LocalTime
        {
            get { return Utilities.GetTime(_info.dt); }
        }

        public string Sunrise
        {
            get { return string.Format(AppConstants.Strings.SUNRISE_FORMAT, Utilities.GetTime(_info.sys.sunrise)); }
        }

        public string Sunset
        {
            get { return string.Format(AppConstants.Strings.SUNSET_FORMAT, Utilities.GetTime(_info.sys.sunset)); }
        }

        public string Humidity
        {
            get { return string.Format(AppConstants.Strings.HUMIDITY_FORMAT, _info.main.humidity); }
        }

        public string Pressure
        {
            get { return string.Format(AppConstants.Strings.PRESSURE_FORMAT, _info.main.pressure); }
        }

        public string Wind
        {
            get { return string.Format(AppConstants.Strings.WIND_FORMAT, _info.wind.speed); }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
