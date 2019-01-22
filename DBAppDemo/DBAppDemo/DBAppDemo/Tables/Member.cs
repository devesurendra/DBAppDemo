using System;
using SQLite;

namespace DBAppDemo.Tables
{
    public class Member
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }

        public Member()
        {
        }
    }
}
