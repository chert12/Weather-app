using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarin_demo.Services;

namespace xamarin_demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CityEntry.Completed += OnCityEntered; 
        }

        private async void OnCityEntered(object sender, EventArgs args)
        {
            NetworkAdapter nd = new NetworkAdapter();
            var info = await nd.GetCurreentWeatherInfo(CityEntry.Text);
            System.Diagnostics.Debug.WriteLine(info.name);
            if(null != info)
            {
                WeatherInfo.Text = $"City: {info.name}\nTemperatute: {info.main.temp}\nPressure: {info.main.pressure}\nHumidity: {info.main.humidity}";
            }
        }
    }
}
