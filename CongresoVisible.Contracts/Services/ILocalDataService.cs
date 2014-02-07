using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongresoVisible.Models;

namespace CongresoVisible.Contracts.Services
{
    public interface ILocalDataService 
    {
        List<Person> GetFollowing();
        void SavePerson(Person person);
        void RemovePerson(int id);
    }
}
