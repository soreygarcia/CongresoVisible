using CongresoVisible.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.FakeServices
{
    public class FakeLocalDataService : ILocalDataService
    {
        public Action Callback { get; set; }

        public void GetFollowing()
        {
            Callback();
        }

        public void SavePerson(Contracts.ViewModels.IPersonViewModel person)
        {
            Callback();
        }

        public void RemovePerson(int id)
        {
            Callback();
        }
    }
}
