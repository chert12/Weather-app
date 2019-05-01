using dotMorten.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_demo.Data;
using xamarin_demo.Data.DatabaseModels;
using xamarin_demo.Services;
using xamarin_demo.ViewModels;

namespace xamarin_demo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCityModal : ContentPage
	{
		public AddCityModal (Action onClose)
		{
			InitializeComponent ();
            this.BindingContext = new CitiesModalViewModel(onClose, entry, Navigation);
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var model = this.BindingContext as CitiesModalViewModel;
            model?.OnDisappearing();
        }
    }
}