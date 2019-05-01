using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using xamarin_demo.Pages;

namespace xamarin_demo.ViewModels
{
    public class WeatherPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<CurrentWeatherViewModel> Pages { get; set; }
        private INavigation _navigation;

        public WeatherPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            InitModel();
        }

        private void InitModel()
        {
            try
            {
                Pages = new ObservableCollection<CurrentWeatherViewModel>(new List<CurrentWeatherViewModel>());

                var items = App.Database.GetUserWeatherData();
                foreach (var i in items)
                {
                    Pages.Add(new CurrentWeatherViewModel(i, _navigation));
                }
                OnPropertyChanged("Pages");
                if(Pages.Count <= 0)
                {
                    _navigation.PushAsync(new CitiesPage());
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
