using System;
using System.Collections.Generic;
using System.Text;
using xamarin_demo.Data.Api;
using System.Linq;

namespace xamarin_demo.Data
{
    [Serializable]
    public class CityWeatherData
    {
        public string CityName { get; set; }
        public long CityId { get; set; }
        public float Temperature { get; set; }
        public string WeatherInfo { get; set; }
        public int MainWeatherImageId { get; set; }
        public long LastUpdateTime { get; set; }
        public long SunriseTime { get; set; }
        public long SunsetTime { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }
        public float Wind { get; set; }

        public static CityWeatherData FromApiData(CurrentWeatherInfo apiInfo)
        {
            var data = new CityWeatherData();

            if(null != apiInfo)
            {
                data.CityName = apiInfo.name;
                data.CityId = apiInfo.id;
                data.Temperature = apiInfo.main.temp;
                foreach (var inf in apiInfo.weather)
                {
                    var end = " ";
                    if(apiInfo.weather.Count > 1)
                    {
                        end = " ,";
                    }
                    data.WeatherInfo = inf.description + end;
                }
                data.MainWeatherImageId = apiInfo.weather[0].id;
                data.LastUpdateTime = apiInfo.dt;
                data.SunriseTime = apiInfo.sys.sunrise;
                data.SunsetTime = apiInfo.sys.sunset;
                data.Humidity = apiInfo.main.humidity;
                data.Pressure = apiInfo.main.pressure;
                data.Wind = apiInfo.wind.speed;
            }

            return data;
        }
    }
}
