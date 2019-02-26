using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using xamarin_demo.Data.Api;

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

        public float Temperature
        {
            get { return _info.main.temp; }
        }

        public string City
        {
            get { return _info.name; }

        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
