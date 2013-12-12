using CongresoVisible.Contracts.Services;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices
{
    public class FakeJsonService : ServiceBase, IJsonService
    {
        public Action Callback { get; set; }

        public void GetFilters()
        {
            Callback();
        }

        public void GetPeople(string filter)
        {
            Callback();
        }

        public void GetPerson(int id)
        {
            Callback();
        }

        public void GetParties()
        {
            Callback();
        } 
    }
}
