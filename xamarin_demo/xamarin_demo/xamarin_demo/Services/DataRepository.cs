using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using xamarin_demo.Data;
using xamarin_demo.Data.DatabaseModels;

namespace xamarin_demo.Services
{
    public sealed class DataRepository
    {
        SQLiteConnection database;
        public DataRepository()
        {
            try
            {
                var ds = DependencyService.Get<ISQLite>();
                if(null == ds)
                {
                    System.Diagnostics.Debug.WriteLine("Dependency service is not implemented for current platform");
                    return;
                }
                string databasePath = ds.GetDbPath(AppConstants.Strings.DATABASE_NAME);
                database = new SQLiteConnection(databasePath);
                database.CreateTable<CityWeatherData>();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public string GetWeatherIcon(int code)
        {
            string res = "";

            try
            {
                int id = database.Table<IconComparerDbElement>().Where(i => i.Code == code).FirstOrDefault().ImageId;
                res = database.Table<WeatherIconDbElement>().Where(i => i.Id == id).FirstOrDefault().Image;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return res;
        }

        public List<CityDataModel> GetCitiesWithPrefix(string cityName)
        {
            var res = new List<CityDataModel>();

            try
            {
                res = database.Table<CityDataModel>().Where(i => i.City.StartsWith(cityName, StringComparison.CurrentCultureIgnoreCase)).Take(AppConstants.Values.SUGGEST_MAX_COUNT).ToList();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return res;
        }

        public List<CityWeatherData> GetUserWeatherData()
        {
            var res = new List<CityWeatherData>();

            try
            {
                res = database.Table<CityWeatherData>().ToList();
                //res = database.Query<CityWeatherData>("SELECT * FROM [UserWeatherData]");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return res;
        }

        public void DeleteUserWeatherData(int cityId)
        {
            try
            {
                var tmpData = database.Table<CityWeatherData>().Where(i => i.CityId == cityId).FirstOrDefault();
                if (null != tmpData)
                {
                    database.Delete(tmpData);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public void AddUserWeatherData(CityWeatherData data)
        {
            try
            {
                var tmpData = database.Table<CityWeatherData>().Where(i => i.CityId == data.CityId).FirstOrDefault();
                if(null != tmpData)
                {
                    UpdateUserWeatherData(data);
                }
                else
                {
                    database.Insert(data);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public void UpdateUserWeatherData(CityWeatherData data)
        {
            try
            {
                var tmpData = database.Table<CityWeatherData>().Where(i => i.CityId == data.CityId).FirstOrDefault();
                if (null != tmpData)
                {
                    database.Update(data);
                }
                else
                {
                    AddUserWeatherData(data);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }

    [Table("IconComparer")]
    public class IconComparerDbElement
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int Id { get; set; }
        [Column("CODE")]
        public int Code { get; set; }
        [Column("IMAGE_ID")]
        public int ImageId { get; set; }
    }

    [Table("WeatherIcons")]
    public class WeatherIconDbElement
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int Id { get; set; }
        [Column("IMAGE")]
        public string Image { get; set; }
    }
}
