using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

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
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public string GetWeatherIcon(int code)
        {
            string res = "";

            int id = database.Table<IconComparerDbElement>().Where(i => i.Code == code).FirstOrDefault().ImageId;
            res = database.Table<WeatherIconDbElement>().Where(i => i.Id == id).FirstOrDefault().Image;

            return res;
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
