using CongresoVisible.Contracts.Services.Common;
using CongresoVisible.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.Contracts.Services
{
    public interface IJsonService : IContextLocator
    {
        void GetPeople(string filter);
        void GetPerson(int id);
        void GetParties();
        void GetFilters();
    }
}


