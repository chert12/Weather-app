using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarin_demo.Services;
using xamarin_demo.ViewModels;

namespace xamarin_demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Init();
            //CityEntry.Completed += OnCityEntered; 

        }

        private async void OnCityEntered(object sender, EventArgs args)
        {
           // NetworkAdapter nd = new NetworkAdapter();
            //var info = await nd.GetCurreentWeatherInfo(CityEntry.Text);
            //.BindingContext = new CurrentWeatherViewModel(info);
        }

        private async void Init()
        {
            NetworkAdapter nd = new NetworkAdapter();
            var info = await nd.GetCurreentWeatherInfo("Kharkiv");
            this.BindingContext = new CurrentWeatherViewModel(info);
        }
    }
}
