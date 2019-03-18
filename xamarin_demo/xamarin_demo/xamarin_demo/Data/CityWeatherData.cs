using System;
using System.Collections.Generic;
using System.Text;
using xamarin_demo.Data.Api;
using System.Linq;
using SQLite;

namespace xamarin_demo.Data
{
    [Serializable, Table("UserWeatherData")]
    public class CityWeatherData
    {
        [Unique, PrimaryKey, NotNull, Column("ID")]
        public int Id { get; set; }
        [NotNull, Column("CITY_NAME")]
        public string CityName { get; set; }
        [NotNull, Column("COUNTRY_NAME")]
        public string CountryName { get; set; }
        [NotNull, Column("CITY_ID")]
        public long CityId { get; set; }
        [Column("TEMPERATURE")]
        public float Temperature { get; set; }
        [Column("WEATHER_INFO")]
        public string WeatherInfo { get; set; }
        [Column("IMAGE_ID")]
        public int MainWeatherImageId { get; set; }
        [Column("LAST_UPDATE")]
        public long LastUpdateTime { get; set; }
        [Column("SUNRISE")]
        public long SunriseTime { get; set; }
        [Column("SUNSET")]
        public long SunsetTime { get; set; }
        [Column("HUMIDITY")]
        public float Humidity { get; set; }
        [Column("PRESSURE")]
        public float Pressure { get; set; }
        [Column("WIND")]
        public float Wind { get; set; }

        public static CityWeatherData FromApiData(CurrentWeatherInfo apiInfo)
        {
            var data = new CityWeatherData();

            if(null != apiInfo)
            {
                data.CityName = apiInfo.name;
                data.CountryName = apiInfo.sys.country;
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
