using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongresoVisible.Contracts.ViewModels;

namespace CongresoVisible.Contracts.Services
{
    public interface ILocalDataService
    {
        void GetFollowing();
        void SavePerson(IPersonViewModel person);
        void RemovePerson(int id);
    }
}
