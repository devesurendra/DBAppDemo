using System;
using DBAppDemo.Services;
using SQLite;
using System.IO;
using DBAppDemo.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOS_SQLiteConnectionProvider))]
namespace DBAppDemo.iOS.Services
{
    public class IOS_SQLiteConnectionProvider : ISQLiteConnectionProvider
    {
        private SQLiteConnection Connection { get; set; }

        public SQLiteConnection GetConnection()
        {
            if (this.Connection != null ) { return this.Connection; }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "..", "Library", "database.db3");
            return this.Connection = new SQLiteConnection(path);
        }
    }
}
