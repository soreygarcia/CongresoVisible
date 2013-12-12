using CongresoVisible.Contracts.ViewModels;
using CongresoVisible.Models;
using CongresoVisible.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongresoVisible.ViewModels.Helpers
{
    class ViewModelHelper
    {
        internal static void SetPeople(IMainViewModel context, PeopleContainer result)
        {
            throw new NotImplementedException();
        }

        internal static void SetSelectedPerson(IMainViewModel context, Person result)
        {
            throw new NotImplementedException();
        }

        internal static void SetParties(IMainViewModel context, PartiesContainer result)
        {
            ObservableCollection<IPartyViewModel> parties = new ObservableCollection<IPartyViewModel>();
            foreach(var item in result.results)
            {
                parties.Add(new PartyViewModel() { 
                    Name = item.name
                });
            }

            context.Parties = parties;
        }
    }
}
