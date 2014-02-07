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
        internal static void SetPeople(MainViewModel context, PeopleContainer result)
        {
            throw new NotImplementedException();
        }

        internal static void SetSelectedPerson(MainViewModel context, Person result)
        {
            throw new NotImplementedException();
        }

        internal static void SetParties(MainViewModel context, PartiesContainer result)
        {
            ObservableCollection<PartyViewModel> parties = new ObservableCollection<PartyViewModel>();
            foreach(var item in result.results)
            {
                parties.Add(new PartyViewModel() { 
                    Name = item.name
                });
            }

            context.Parties = parties;
        }

        internal static void SetRandomPeople(MainViewModel mainViewModel, PeopleContainer result)
        {
            throw new NotImplementedException();
        }

        internal static void SetFilters(MainViewModel mainViewModel, FiltersContainer result)
        {
            throw new NotImplementedException();
        }
    }
}
