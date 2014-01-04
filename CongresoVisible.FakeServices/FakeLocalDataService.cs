using CongresoVisible.Contracts.Services;
using CongresoVisible.Contracts.ViewModels;
using CongresoVisible.FakeServices.Contracts;
using CongresoVisible.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices
{
    public class FakeLocalDataService : ILocalDataService, IFakeService
    {
        public Action Callback { get; set; }

        public List<Person> GetFollowing()
        {
            Callback();
            return new List<Person>();
        }

        public void SavePerson(Person person)
        {
            Callback();
        }

        public void RemovePerson(int id)
        {
            Callback();
        }

        public T GetService<T>()
        {
            throw new NotImplementedException();
        }
    }
}
