using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using xamarin_demo.Data.Api;

namespace xamarin_demo.Services
{
    public sealed class NetworkAdapter
    {
        #region data

        #endregion

        #region interface

        public async Task<CurrentWeatherInfo> GetCurreentWeatherInfo(string city)
        {
            if(string.IsNullOrEmpty(city))
            {
                return null;
            }
            try
            {
                HttpClient client = new HttpClient();
                string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&id=524901&APPID=f7ed34c0ea1213c3a708ec60f163e6f7";
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);

                return JsonConvert.DeserializeObject<CurrentWeatherInfo>(o.ToString());
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
            return null;
        }
        

        #endregion

        #region implementation

        private bool IsConnected()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;

            if (!isConnected)
            {
                if (null != OnNoInternetConnection)
                {
                    OnNoInternetConnection(this, new EventArgs());
                }
            }
            return isConnected;
        }

        #endregion

        #region properties

        public EventHandler OnNoInternetConnection { get; set; }

        #endregion
    }
}
