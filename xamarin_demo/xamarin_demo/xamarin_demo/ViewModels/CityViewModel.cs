using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using xamarin_demo.Services;
using Xamarin.Forms;

namespace xamarin_demo.ViewModels
{
    public class CityViewModel
    {
        public CityViewModel(string name, int id, Action removeCallback)
        {
            CityName = name;
            Id = id;
            _removeCallback = removeCallback;
            RemoveCommand = new Command(RemoveCommandFunc);
        }
        public int Id { get; set; }
        public string CityName { get; set; }
        public ICommand RemoveCommand { get; private set; }
        private Action _removeCallback;

        private async void RemoveCommandFunc()
        {
            var answer = await App.Current.MainPage.DisplayAlert(AppConstants.Strings.DIALOG_INFO,
                String.Format(AppConstants.Strings.DIALOG_CITY_DELETE, CityName),
                AppConstants.Strings.DIALOG_YES,
                AppConstants.Strings.DIALOG_NO);

            if (answer)
            {
                App.Database.DeleteUserWeatherData(Id);
                _removeCallback?.Invoke();
            }
        }
    }
}
