using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xamarin_demo.Pages;
using xamarin_demo.Services;

namespace xamarin_demo.ViewModels
{
    public class CitiesPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<CityViewModel> Cities { get; set; }
        public ICommand AddCityCommand { get; private set; }
        public string Title => AppConstants.Strings.CITY_PAGE_TITLE;
        public string ToolbarIcon { get; private set; }
        private IImageProvider _imageProvider;
        private INavigation _navigation;

        public CitiesPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _imageProvider = DependencyService.Get<IImageProvider>();
            ToolbarIcon = _imageProvider.GetImagePath(AppConstants.Strings.ADD_CITY_IMAGE);
            AddCityCommand = new Command(ShowAddCityModal);
            InitCities();
        }

        private void InitCities()
        {
            var userCities = App.Database.GetUserWeatherData();
            Cities = new List<CityViewModel>();
            foreach (var ct in userCities)
            {
                Cities.Add(new CityViewModel(string.Format(AppConstants.Strings.CITY_FORMAT, ct.CityName, ct.CountryName), (int)ct.CityId, InitCities));
            }
            OnPropertyChanged("Cities");
        }

        private void ShowAddCityModal()
        {
            _navigation.PushModalAsync(new AddCityModal(InitCities));
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
