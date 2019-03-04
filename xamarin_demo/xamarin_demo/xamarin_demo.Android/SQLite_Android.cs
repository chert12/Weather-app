using System;
using System.IO;
using xamarin_demo.Droid;
using xamarin_demo.Services;
using Xamarin.Forms;
using Android.Content;

[assembly: Xamarin.Forms.Dependency(typeof(xamarin_demo.Droid.SQLite_Android))]
namespace xamarin_demo.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDbPath(string dbName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, dbName);
            if (!File.Exists(path))
            {
                Context context = Android.App.Application.Context;
                var dbAssetStream = context.Assets.Open(dbName);

                var dbFileStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
                var buffer = new byte[1024];

                int b = buffer.Length;
                int length;

                while ((length = dbAssetStream.Read(buffer, 0, b)) > 0)
                {
                    dbFileStream.Write(buffer, 0, length);
                }

                dbFileStream.Flush();
                dbFileStream.Close();
                dbAssetStream.Close();
            }

            return path;
        }
    }
}