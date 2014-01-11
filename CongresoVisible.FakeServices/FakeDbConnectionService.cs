using CongresoVisible.FakeServices.Contracts;
using Infrastructure.Common;
using Infrastructure.Common.Contracts;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices
{
    public class FakeDbConnectionService : IFakeService, IDbConnectionService
    {
        public Action Callback { get; set; }

        public SQLiteConnection Connection
        {
            get { return null; }
        }

        public string ConnectionString
        {
            get { return string.Empty; }
        }
    }
}
