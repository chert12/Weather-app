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

        private string _temperature;
        private string _city;
        private string _mainWeatherImage;
        private string _weatherInfo;
        private string _localTime;
        private string _sunrise;
        private string _sunset;
        private string _humidity;
        private string _pressure;
        private string _wind;



        public CurrentWeatherViewModel(CityWeatherData info)
        {
            Init(info);
        }

        public async void Init(CityWeatherData info)
        {
            _imageProvider = DependencyService.Get<IImageProvider>();

            DateTime now = DateTime.Now.ToLocalTime();
            TimeSpan t = now - Utilities.GetTime(info.LastUpdateTime);
            if (t.TotalHours > AppConstants.Values.MAX_UPDATE_TIME_DIFF)
            {
                NetworkAdapter nd = new NetworkAdapter();
                var dt = await nd.GetCurreentWeatherInfo(info.CityId.ToString());
                info = CityWeatherData.FromApiData(dt);
            }

            Temperature = string.Format(AppConstants.Strings.CELSIUS_FORMAT, Utilities.KelvinToCelcius(info.Temperature));
            City = string.Format(AppConstants.Strings.CITY_FORMAT, info.CityName, info.CountryName);
            MainWeatherImage = _imageProvider.GetImagePath(App.Database.GetWeatherIcon(info.MainWeatherImageId));
            WeatherDescription = info.WeatherInfo;
            LocalTime = string.Format(AppConstants.Strings.LAST_UPDATE_FORMAT, Utilities.GetFormattedTime(info.LastUpdateTime));
            Sunrise = string.Format(AppConstants.Strings.SUNRISE_FORMAT, Utilities.GetFormattedTime(info.SunriseTime));
            Sunset = string.Format(AppConstants.Strings.SUNSET_FORMAT, Utilities.GetFormattedTime(info.SunsetTime));
            Humidity = string.Format(AppConstants.Strings.HUMIDITY_FORMAT, info.Humidity);
            Pressure = string.Format(AppConstants.Strings.PRESSURE_FORMAT, info.Pressure);
            Wind = string.Format(AppConstants.Strings.WIND_FORMAT, info.Wind);
        }

        public string Temperature
        {
            get { return _temperature; }
            private set
            {
                _temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        public string City
        {
            get { return _city; }
            private set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        public string MainWeatherImage
        {
            get { return _mainWeatherImage; }
            private set
            {
                _mainWeatherImage = value;
                OnPropertyChanged("MainWeatherImage");
            }
        }

        public string WeatherDescription
        {
            get { return _weatherInfo; }
            private set
            {
                _weatherInfo = value;
                OnPropertyChanged("WeatherDescription");
            }
        }

        public string LocalTime
        {
            get { return _localTime; }
            private set
            {
                _localTime = value;
                OnPropertyChanged("LocalTime");
            }
        }

        public string Sunrise
        {
            get { return _sunrise; }
            private set
            {
                _sunrise = value;
                OnPropertyChanged("Sunrise");
            }
        }

        public string Sunset
        {
            get { return _sunset; }
            private set
            {
                _sunset = value;
                OnPropertyChanged("Sunset");
            }
        }

        public string Humidity
        {
            get { return _humidity; }
            private set
            {
                _humidity = value;
                OnPropertyChanged("Humidity");
            }
        }

        public string Pressure
        {
            get { return _pressure; }
            private set
            {
                _pressure = value;
                OnPropertyChanged("Pressure");
            }
        }

        public string Wind
        {
            get { return _wind; }
            private set
            {
                _wind = value;
                OnPropertyChanged("Wind");
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
