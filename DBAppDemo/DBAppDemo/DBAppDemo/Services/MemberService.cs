using System;
using System.Collections.Generic;
using System.Linq;
using DBAppDemo.Tables;
using SQLite;

namespace DBAppDemo.Services
{
    public interface IMemberService
    {
        IEnumerable<Member> GetMembers();
        string AddMember(Member member);
        string DeleteMember(int id);
    }

    public class MemberService: IMemberService
    {
        private readonly ISQLiteConnectionProvider ConnectionProvider;
        private SQLiteConnection Connection { get; }

        public MemberService(ISQLiteConnectionProvider connectionProvider)
        {
            this.ConnectionProvider = connectionProvider;
            this.Connection = this.ConnectionProvider.GetConnection();
            this.Connection.CreateTable<Member>();
        }

        public IEnumerable<Member> GetMembers()
        {
            var members = (from mem in this.Connection.Table<Member>() select mem);
            return members.ToList();
        }

        public string AddMember(Member member)
        {
            this.Connection.Insert(member);
            return "success";
        }

        public string DeleteMember(int id)
        {
            this.Connection.Delete<Member>(id);
            return "success";
        }


    }
}
