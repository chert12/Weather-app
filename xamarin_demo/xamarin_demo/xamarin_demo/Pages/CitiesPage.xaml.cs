using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_demo.Services;

namespace xamarin_demo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CitiesPage : ContentPage
	{
        private IImageProvider _imageProvider;
        public List<CityViewModel> Cities { get; set; }

        public CitiesPage()
		{
			InitializeComponent ();
            _imageProvider = DependencyService.Get<IImageProvider>();
            Title = AppConstants.Strings.CITY_PAGE_TITLE;
            ToolbarItems.Add(new ToolbarItem("Add", _imageProvider.GetImagePath(AppConstants.Strings.ADD_CITY_IMAGE), () =>
            {
                Navigation.PushModalAsync(new AddCityModal(InitCities));
            }));
            InitCities();
            this.BindingContext = this;
        }

        private async void OnRemoveButtonClicked(object sender, EventArgs e)
        {
            var btn = sender as ImageButton;
            if (null != btn)
            {
                var answer = await DisplayAlert(AppConstants.Strings.DIALOG_INFO, AppConstants.Strings.DIALOG_CITY_DELETE, AppConstants.Strings.DIALOG_YES, AppConstants.Strings.DIALOG_NO);
                if (answer)
                {
                    App.Database.DeleteUserWeatherData((int)btn.CommandParameter);
                    InitCities();
                }
            }
        }

        private void InitCities()
        {
            var userCities = App.Database.GetUserWeatherData();
            Cities = new List<CityViewModel>();
            foreach (var ct in userCities)
            {
                Cities.Add(new CityViewModel(string.Format(AppConstants.Strings.CITY_FORMAT, ct.CityName, ct.CountryName), (int)ct.CityId));
            }
            OnPropertyChanged("Cities");
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    InitCities();
        //}
    }

    public class CityViewModel
    {
        public CityViewModel(string name, int id)
        {
            CityName = name;
            Id = id;
        }
        public int Id { get; set; }
        public string CityName { get; set; }
    }
}