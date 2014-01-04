using CongresoVisible.Contracts.Services;
using CongresoVisible.FakeServices.Contracts;
using CongresoVisible.Models;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices
{
    public class FakeJsonService : ServiceBase, IJsonService, IFakeService
    {
        public Action Callback { get; set; }

        public Task<PeopleContainer> GetPeople(string filter)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PartiesContainer> GetParties()
        {
            throw new NotImplementedException();
        }

        public Task<FiltersContainer> GetFilters()
        {
            throw new NotImplementedException();
        }

        public Task<PeopleContainer> GetPeopleByParty(int party)
        {
            throw new NotImplementedException();
        }
    }
}
