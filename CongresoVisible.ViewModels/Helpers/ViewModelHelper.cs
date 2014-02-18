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
            //throw new NotImplementedException();
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

        internal static void SetRandomPerson(MainViewModel mainViewModel, Person result, int index)
        {
            PersonViewModel person = new PersonViewModel()
            {
                Name = string.Format("{0} {1}", result.first_name, result.last_name),
                Url = result.url,
                WebUrl = result.web_url,
                Gender = result.gender,
                CandidateFor = result.candidate_for,
                MediumImage = result.images.medium,
                ListNumber = result.list_number,
                Party = new PartyViewModel()
                {
                    Id = result.party.id,
                    Name = result.party.name,
                    Logo = result.party.avatar
                }
            };

            mainViewModel.RandomPeople[index] = person;
        }

        internal static void SetFilters(MainViewModel mainViewModel, FiltersContainer result)
        {
            //throw new NotImplementedException();
        }

        internal static void InitilizeRandomPeople(MainViewModel mainViewModel, int featuredPeopleCount)
        {
            PersonViewModel fakePerson = new PersonViewModel()
            {
                MediumImage = "/Assets/IconoGris.png"
            };

            mainViewModel.RandomPeople = new ObservableCollection<PersonViewModel>();
            for (int i = 0; i < featuredPeopleCount; i++)
            {
                mainViewModel.RandomPeople.Add(fakePerson);
            }
        }
    }
}
