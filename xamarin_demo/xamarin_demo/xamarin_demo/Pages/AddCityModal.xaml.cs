using dotMorten.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_demo.Data.DatabaseModels;
using xamarin_demo.Services;

namespace xamarin_demo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCityModal : ContentPage
	{
        private List<CityDataModel> _lastSuggestion;

		public AddCityModal ()
		{
			InitializeComponent ();
            //entry.Su = new List<string> { "Kharkiv", "Kyiv" };
		}

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                _lastSuggestion = App.Database.GetCities(entry.Text);
                if(null != _lastSuggestion)
                {
                    var newSuggestion = new List<string>();
                    foreach(var item in _lastSuggestion)
                    {
                        newSuggestion.Add(String.Format(AppConstants.Strings.CITY_FORMAT, item.City, item.Country));
                    }
                    entry.ItemsSource = newSuggestion;
                }
            }
        }


        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            
        }


        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
            }
            else
            {
                // User hit Enter from the search box. Use args.QueryText to determine what to do.
            }
        }
    }
}