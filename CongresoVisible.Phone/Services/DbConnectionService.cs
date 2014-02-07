using CongresoVisible.Contracts.Services;
using Infrastructure.Common;
using Infrastructure.Common.Contracts;
using SQLite.Net;
using SQLite.Net.Platform.WindowsPhone8.CSharpSqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Phone.Services
{
    public class DbConnectionService : IDbConnectionService
    {
        string connectionString = string.Empty;

        SQLiteConnection connection;

        ISettingsService settingsService;

        public DbConnectionService(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
            connectionString = settingsService.GetSettingsValue("DataBasePath");

            InitializeConnection(connectionString);
        }

        public SQLiteConnection Connection
        {
            get { return connection; }
        }

        public string ConnectionString
        {
            get { return connectionString; }
        }

        private void InitializeConnection(string connectionString)
        {

            #if WINDOWS
                        // Execute code that is specific to Windows

            #elif WINDOWS_PHONE
            // Execute code that is specific to Windows Phone
            connection = new SQLiteConnection(new SQLitePlatformWP8CSharp(), connectionString);

            #elif _ANDROID_ //MONODROID
                        // Execute code that is specific to Android
      
            #else
                        // Print a compile-time error message
            #error The platform is not specified or is unsupported by this app.
            #endif
        }


    }
}
