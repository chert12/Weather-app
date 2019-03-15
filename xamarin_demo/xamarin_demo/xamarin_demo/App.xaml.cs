using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_demo.Pages;
using xamarin_demo.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace xamarin_demo
{
    public partial class App : Application
    {
        public static DataRepository database;
        public static DataRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataRepository();
                }
                return database;
            }
        }

        public App()
        {
            try
            {
                InitializeComponent();
                //MainPage = new NavigationPage(new MainPage());
                MainPage = new NavigationPage(new WeatherMain());
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
