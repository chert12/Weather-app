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

        public CitiesPage()
		{
			InitializeComponent ();
            _imageProvider = DependencyService.Get<IImageProvider>();
            Title = AppConstants.Strings.CITY_PAGE_TITLE;
            ToolbarItems.Add(new ToolbarItem("Add", _imageProvider.GetImagePath(AppConstants.Strings.ADD_CITY_IMAGE), () =>
            {
                DisplayAlert("Уведомление", "Пришло новое сообщение", "ОK");
            }));
        }
	}
}