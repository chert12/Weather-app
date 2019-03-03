using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_demo.Data.Api
{
    [Serializable]
    public class CurrentWeatherInfo
    {
        public CoordinatesInfo coord;
        public IEnumerable<WeahterInfo> weather;
        public WeatherMainInfo main;
        public float visibility;
        public WindInfo wind;
        public CloudsInfo clouds;
        public long dt;
        public CountryInfo sys;
        public long id;
        public string name; // city name
        public int cod;
    }

    [Serializable]
    public class CoordinatesInfo
    {
        public float lon;
        public float lat;
    }

    [Serializable]
    public class WeahterInfo
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }

    [Serializable]
    public class WeatherMainInfo
    {
        public float temp;
        public float pressure;
        public float humidity;
        public float temp_min;
        public float temp_max;
    }

    [Serializable]
    public class WindInfo
    {
        public float speed;
        public float deg;
    }

    [Serializable]
    public class CloudsInfo
    {
        public float all;
    }

    [Serializable]
    public class CountryInfo
    {
        public int type;
        public long id;
        public float message;
        public string country;
        public long sunrise;
        public long sunset;
    }
}
