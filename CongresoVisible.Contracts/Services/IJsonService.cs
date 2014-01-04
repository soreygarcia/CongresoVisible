using CongresoVisible.Contracts.Common;
using CongresoVisible.Contracts.ViewModels;
using CongresoVisible.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Contracts.Services
{
    public interface IJsonService : IServiceLocator
    {
        Task<PeopleContainer> GetPeople(string filter);
        Task<Person> GetPerson(int id);
        Task<PartiesContainer> GetParties();
        Task<FiltersContainer> GetFilters();
        Task<PeopleContainer> GetPeopleByParty(int party);
    }
}


