using SQLite.Net;
using System;
namespace CongresoVisible.Phone.Infrastructure
{
    public interface IDbConnectionService
    {
        SQLiteConnection Connection { get; }
        string ConnectionString { get; }
       
    }
}
