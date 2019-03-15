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
                //DisplayAlert("Уведомление", "Пришло новое сообщение", "ОK");
                Navigation.PushModalAsync(new AddCityModal());
            }));
            Cities = new List<CityViewModel>
            {
                new CityViewModel(){CityName="Kharkiv, Ukraine"},
                new CityViewModel(){CityName="Kyiv, Ukraine"},
                new CityViewModel(){CityName="Dnipro, Ukraine"},
                new CityViewModel(){CityName="Odessa, Ukraine"},
                new CityViewModel(){CityName="Donetsk, Ukraine"},
            };
            this.BindingContext = this;
        }

        private void OnRemoveButtonClicked(object sender, EventArgs e)
        {

        }
    }

    public class CityViewModel
    {
        public string CityName { get; set; }
    }
}