using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using Note2018.UWP;
using SQLite;

[assembly: Dependency(typeof(SQLite_UWP))]

namespace Note2018.UWP
{
    public class SQLite_UWP: ISQLite
    {
        public SQLite_UWP() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            return path;
        }
    }
}
