using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_demo.Services;
using xamarin_demo.ViewModels;

namespace xamarin_demo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CitiesPage : ContentPage
	{
        public CitiesPage()
		{
			InitializeComponent ();
            this.BindingContext = new CitiesPageViewModel(Navigation);
        }
    }
}