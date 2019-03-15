using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin_demo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCityModal : ContentPage
	{
		public AddCityModal ()
		{
			InitializeComponent ();
            //entry.Su = new List<string> { "Kharkiv", "Kyiv" };
		}
	}
}