using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongresoVisible.Contracts.Common;
using CongresoVisible.Models;

namespace CongresoVisible.Contracts.Services
{
    public interface ILocalDataService : IServiceLocator
    {
        List<Person> GetFollowing();
        void SavePerson(Person person);
        void RemovePerson(int id);
    }
}
