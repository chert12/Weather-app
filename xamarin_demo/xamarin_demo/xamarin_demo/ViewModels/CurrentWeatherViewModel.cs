using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using xamarin_demo.Data.Api;
using xamarin_demo.Services;

namespace xamarin_demo.ViewModels
{
    public class CurrentWeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CurrentWeatherInfo _info;

        public CurrentWeatherViewModel(CurrentWeatherInfo info)
        {
            _info = info;
        }

        public string Temperature
        {
            get { return string.Format(AppConstants.Strings.CELSIUS_FORMAT,Utilities.KelvinToCelcius(_info.main.temp)); }
        }

        public string City
        {
            //get { return _info.name; }
            get { return App.Database.GetWeatherIcon(_info.weather.ToList()[0].id); }
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
