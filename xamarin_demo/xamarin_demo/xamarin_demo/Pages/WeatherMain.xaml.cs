using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_demo.Data;
using xamarin_demo.Services;
using xamarin_demo.ViewModels;

namespace xamarin_demo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherMain : CarouselPage
    {
        public WeatherMain()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.SetValue(NavigationPage.BarBackgroundColorProperty, new Color(197, 96, 0));
            Init();
            //ItemsSource = 
        }

        private async void Init()
        {
            //NetworkAdapter nd = new NetworkAdapter();
            //var info = await nd.GetCurreentWeatherInfo("Kharkiv");
            //var info2 = await nd.GetCurreentWeatherInfo("Kiev");
            var items = App.Database.GetUserWeatherData();
            var bindingData = new List<CurrentWeatherViewModel>();
            foreach(var i in items)
            {
                bindingData.Add(new CurrentWeatherViewModel(i));
            }
            ItemsSource = bindingData;
            //ItemsSource = new List<CurrentWeatherViewModel>() { new CurrentWeatherViewModel(CityWeatherData.FromApiData(info)), new CurrentWeatherViewModel(CityWeatherData.FromApiData(info2)) };
        }

        private async void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CitiesPage());
        }
    }
}