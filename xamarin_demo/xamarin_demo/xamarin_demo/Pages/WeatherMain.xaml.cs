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
    public partial class WeatherMain : ContentPage
    {
        public WeatherMain()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new WeatherPageViewModel(Navigation);
        }

        protected override void OnDisappearing()
        {
            UnapplyBindings();
            base.OnDisappearing();
        }

        protected override void OnAppearing()
        {
            try
            {
                BindingContext = new WeatherPageViewModel(Navigation);
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            base.OnAppearing();
        }
    }
}