using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_demo.Services
{
    public static class AppConstants
    {
        public static class Values
        {
            public const float KELVIN_VALUE = 273.15f;
            public const int SUGGEST_MAX_COUNT = 10; // max suggestion cities count
            public const int MAX_UPDATE_TIME_DIFF = 1; // hour
        }

        public static class Strings
        {
            public const string DATABASE_NAME = "weather.sqlite";

            /*** Errors ***/
            public const string ERROR_TITLE = "Error";
            public const string ERROR_NULL_CITY = "City field cannot be empty.";
            public const string ERROR_INCORRECT_CITY = "Please select city from dropdown list.";

            /*** Dialogs ***/
            public const string DIALOG_CLOSE = "Close";
            public const string DIALOG_INFO = "Info";
            public const string DIALOG_CITY_ADDED = "New city succesfully added.";
            public const string DIALOG_CITY_DELETE = "Are you sure want to delete {0} from cities list?";
            public const string DIALOG_OK = "Ok";
            public const string DIALOG_YES = "Yes";
            public const string DIALOG_NO = "No";

            /*** Images ***/
            public const string IOS_IMAGE_FOLDER = "Images";
            public const string HUMIDITY_IMAGE = "wet.png";
            public const string WIND_IMAGE = "wind.png";
            public const string PRESSURE_IMAGE = "flag.png";
            public const string SUNRISE_IMAGE = "sunrise.png";
            public const string SUNSET_IMAGE = "sunset.png";
            public const string ADD_CITY_IMAGE = "round_add_white_24.png";

            /*** Text formats ***/
            public const string CELSIUS_FORMAT = "{0}°C";
            public const string FAHRENHEIT_FORMAT = "{0}°F";
            public const string SUNRISE_FORMAT = "Sunrise\n{0}";
            public const string SUNSET_FORMAT = "Sunset\n{0}";
            public const string HUMIDITY_FORMAT = "Humitidy\n{0}%";
            public const string PRESSURE_FORMAT = "Pressure\n{0}";
            public const string WIND_FORMAT = "Wind\n{0} km/h";
            public const string CITY_FORMAT = "{0}, {1}";
            public const string LAST_UPDATE_FORMAT = "Last update at {0}";

            public const string CITY_PAGE_TITLE = "Cities";
        }
    }
}
