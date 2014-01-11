using SQLite.Net;
using System;
namespace Infrastructure.Common.Contracts
{
    public interface IDbConnectionService
    {
        SQLiteConnection Connection { get; }
        string ConnectionString { get; }
       
    }
}
