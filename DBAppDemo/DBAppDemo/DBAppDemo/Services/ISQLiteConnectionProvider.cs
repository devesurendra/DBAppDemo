using System;
using SQLite;

namespace DBAppDemo.Services
{
    public interface ISQLiteConnectionProvider
    {
        SQLiteConnection GetConnection();
    }
}
