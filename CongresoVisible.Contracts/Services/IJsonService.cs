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
    public interface IJsonService 
    {
        Task<PeopleContainer> GetPeopleAsync(string filter);
        Task<Person> GetPersonAsync(int id);
        Task<PartiesContainer> GetPartiesAsync();
        FiltersContainer GetFilters();
        Task<PeopleContainer> GetPeopleByPartyAsync(int party);
    }
}


