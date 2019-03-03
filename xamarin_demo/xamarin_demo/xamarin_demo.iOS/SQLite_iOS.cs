using System;
using Xamarin.Forms;
using System.IO;
using xamarin_demo.Services;
using xamarin_demo.iOS;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace xamarin_demo.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }

        public string GetDbPath(string dbName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, dbName);

            return path;
        }
    }
}