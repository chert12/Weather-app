using System;
using System.IO;
using xamarin_demo.Droid;
using xamarin_demo.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(xamarin_demo.Droid.SQLite_Android))]
namespace xamarin_demo.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDbPath(string dbName)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, dbName);
            return path;
        }
    }
}