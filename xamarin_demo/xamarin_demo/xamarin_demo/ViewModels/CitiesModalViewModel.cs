using dotMorten.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using xamarin_demo.Data;
using xamarin_demo.Data.DatabaseModels;
using xamarin_demo.Services;

namespace xamarin_demo.ViewModels
{
    public class CitiesModalViewModel
    {
        private List<CityDataModel> _lastSuggestion;
        private Action _onCloseAction;
        private AutoSuggestBox _autosuggestBox;
        private INavigation _navigation;
        public ICommand AddButtonCommand { get; private set; }

        public CitiesModalViewModel(Action onClose, AutoSuggestBox autosuggestBox, INavigation navigation)
        {
            _onCloseAction = onClose;
            _autosuggestBox = autosuggestBox;
            _navigation = navigation;
            _autosuggestBox.TextChanged += AutoSuggestBox_TextChanged;
            AddButtonCommand = new Command(OnAddButtonClicked);
        }

        public void OnDisappearing()
        {
            if (null != _onCloseAction)
            {
                try
                {
                    _onCloseAction();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
        }

        private void AutoSuggestBox_TextChanged(object sender, AutoSuggestBoxTextChangedEventArgs e)
        {
            if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                _lastSuggestion = App.Database.GetCitiesWithPrefix(_autosuggestBox.Text);
                if (null != _lastSuggestion)
                {
                    var newSuggestion = new List<string>();
                    foreach (var item in _lastSuggestion)
                    {
                        newSuggestion.Add(String.Format(AppConstants.Strings.CITY_FORMAT, item.City, item.Country));
                    }
                    _autosuggestBox.ItemsSource = newSuggestion;
                }
            }
        }

        private void OnAddButtonClicked()
        {
            if (null == _autosuggestBox.Text || string.IsNullOrEmpty(_autosuggestBox.Text))
            {
                App.Current.MainPage.DisplayAlert(AppConstants.Strings.ERROR_TITLE, AppConstants.Strings.ERROR_NULL_CITY, AppConstants.Strings.DIALOG_CLOSE);
                return;
            }
            CityDataModel cityModel = null;
            string cityName = "";
            if (_autosuggestBox.Text.Contains(","))
            {
                var tmp = _autosuggestBox.Text.Split(',');
                cityName = tmp[0];
            }
            else
            {
                cityName = _autosuggestBox.Text;
            }
            foreach (var ct in _lastSuggestion)
            {
                if (ct.City.Equals(cityName))
                {
                    cityModel = ct;
                    break;
                }
            }
            if (null != cityModel)
            {
                CityWeatherData dt = new CityWeatherData() { CityId = cityModel.CityId, CityName = cityModel.City, CountryName = cityModel.Country };
                App.Current.MainPage.DisplayAlert(AppConstants.Strings.DIALOG_INFO, AppConstants.Strings.DIALOG_CITY_ADDED, AppConstants.Strings.DIALOG_OK);
                App.Database.AddUserWeatherData(dt);
                _navigation.PopModalAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert(AppConstants.Strings.ERROR_TITLE, AppConstants.Strings.ERROR_INCORRECT_CITY, AppConstants.Strings.DIALOG_CLOSE);
                return;
            }
        }
    }
}
