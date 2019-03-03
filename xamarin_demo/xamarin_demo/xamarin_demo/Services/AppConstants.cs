﻿using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_demo.Services
{
    public static class AppConstants
    {
        public static class Values
        {
            public const float KELVIN_VALUE = 273.15f;
        }

        public static class Strings
        {
            public const string DATABASE_NAME = "weather.db";
            public const string CELSIUS_FORMAT = "{0}°C";
            public const string FAHRENHEIT_FORMAT = "{0}°F";
            public const string SUNRISE_FORMAT = "Sunrise\n{0}";
            public const string SUNSET_FORMAT = "Sunset\n{0}";
            public const string HUMIDITY_FORMAT = "Humitidy\n{0}%";
            public const string PRESSURE_FORMAT = "Pressure\n{0}";
            public const string WIND_FORMAT = "Wind\n{0} km/h";
        }
    }
}