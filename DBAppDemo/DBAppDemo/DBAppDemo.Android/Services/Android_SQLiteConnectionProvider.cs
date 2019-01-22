using System;
using DBAppDemo.Services;
using SQLite;
using System.IO;
using DBAppDemo.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Android_SQLiteConnectionProvider))]
namespace DBAppDemo.Droid.Services
{
    public class Android_SQLiteConnectionProvider: ISQLiteConnectionProvider
    {
        private SQLiteConnection Connection { get; set; }

        public SQLiteConnection GetConnection()
        {
            if (this.Connection != null) { return this.Connection; }

            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "database.db3");
            return this.Connection = new SQLiteConnection(path);
        }
    }
}
