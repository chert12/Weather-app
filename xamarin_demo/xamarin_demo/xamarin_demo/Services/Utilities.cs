using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_demo.Services
{
    public static class Utilities
    {
        /// <summary>
        /// Convert temperature from kelvin to celsius(metric)
        /// </summary>
        /// <param name="kelvinTemperature">Temperature in kelvin</param>
        /// <returns></returns>
        public static int KelvinToCelcius(float kelvinTemperature)
        {
            return (int)Math.Ceiling(kelvinTemperature - AppConstants.Values.KELVIN_VALUE); // classic formula C = T(K)-263.15
        }

        /// <summary>
        /// Convert temperature from kelvin to fahrenheit(imperial)
        /// </summary>
        /// <param name="kelvinTemperature">Temperature in kelvin</param>
        /// <returns></returns>
        public static float KelvinToFahrenheit(float kelvinTemperature)
        {
            return (int)Math.Ceiling(kelvinTemperature * 9 / 5 - 459.67f); // classic formula F = T(K)*9/5-459.67
        }

        public static string GetFormattedTime(long timestamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
            return dtDateTime.ToString("HH:mm");
        }

        public static DateTime GetTime(long timestamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
