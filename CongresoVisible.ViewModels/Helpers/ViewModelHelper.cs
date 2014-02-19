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

        internal static void SetRandomPerson(MainViewModel context, Person result, int index)
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

            context.RandomPeople[index] = null;
            context.RandomPeople[index] = person;
        }

        internal static void SetFilters(MainViewModel context, FiltersContainer result)
        {
            //throw new NotImplementedException();
        }

        internal static void InitilizeRandomPeople(MainViewModel context, int featuredPeopleCount)
        {
            if (context.RandomPeople == null)
            {
                context.RandomPeople = new ObservableCollection<PersonViewModel>();
                for (int i = 0; i < featuredPeopleCount; i++)
                {
                    context.RandomPeople.Add(new PersonViewModel()
                        {
                            MediumImage = "/Assets/IconoGris.png"
                        });
                }
            }
        }

        internal static void SetPeople(PartyViewModel context, PeopleContainer result)
        {
            context.People = new ObservableCollection<PersonViewModel>();

            foreach (var item in result.results)
            {
                context.People.Add(new PersonViewModel()
                {
                    Name = string.Format("{0} {1}", item.first_name, item.last_name),
                    Url = item.url,
                    WebUrl = item.web_url,
                    Gender = item.gender,
                    CandidateFor = item.candidate_for,
                    MediumImage = item.images.medium,
                    ListNumber = item.list_number,
                    Party = new PartyViewModel()
                    {
                        Id = item.party.id,
                        Name = item.party.name,
                        Logo = item.party.avatar
                    }
                });
            }
        }
    }
}
