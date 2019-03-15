using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using xamarin_demo.Data;
using xamarin_demo.Data.Api;
using xamarin_demo.Services;

namespace xamarin_demo.ViewModels
{
    public class CurrentWeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IImageProvider _imageProvider;

        public CurrentWeatherViewModel(CityWeatherData info)
        {
            _imageProvider = DependencyService.Get<IImageProvider>();
            Temperature = string.Format(AppConstants.Strings.CELSIUS_FORMAT, Utilities.KelvinToCelcius(info.Temperature));
            City = info.CityName;
            MainWeatherImage = _imageProvider.GetImagePath(App.Database.GetWeatherIcon(info.MainWeatherImageId));
            LocalTime = Utilities.GetTime(info.LastUpdateTime);
            Sunrise = string.Format(AppConstants.Strings.SUNRISE_FORMAT, Utilities.GetTime(info.SunriseTime));
            Sunset = string.Format(AppConstants.Strings.SUNSET_FORMAT, Utilities.GetTime(info.SunsetTime));
            Humidity = string.Format(AppConstants.Strings.HUMIDITY_FORMAT, info.Humidity);
            Pressure = string.Format(AppConstants.Strings.PRESSURE_FORMAT, info.Pressure);
            Wind = string.Format(AppConstants.Strings.WIND_FORMAT, info.Wind);
        }

        public string Temperature
        {
            get; private set;
        }

        public string City
        {
            get; private set;
        }

        public string MainWeatherImage
        {
            get; private set;
        }

        public string LocalTime
        {
            get; private set;
        }

        public string Sunrise
        {
            get; private set;
        }

        public string Sunset
        {
            get; private set;
        }

        public string Humidity
        {
            get; private set;
        }

        public string Pressure
        {
            get; private set;
        }

        public string Wind
        {
            get; private set;
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
