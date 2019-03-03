using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_demo.Services
{
    public interface ISQLite
    {
        string GetDbPath(string dbName);
    }
}
