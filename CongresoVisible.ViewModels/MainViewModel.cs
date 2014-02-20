using Autofac;
using CongresoVisible.Models;
using CongresoVisible.Services.Contracts;
using CongresoVisible.ViewModels.Helpers;
using Infrastructure.Common;
using Infrastructure.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Contracts = CongresoVisible.Services.Contracts;

namespace CongresoVisible.ViewModels
{
    public class MainViewModel : BindableBase
    {
        Contracts.IJsonService jsonService;
        Random randomizer = new Random(DateTime.Now.Millisecond);
        List<int> loadedRandomPeople = new List<int>();

        private PersonViewModel selectedPerson;
        public PersonViewModel SelectedPerson
        {
            get
            {
                return this.selectedPerson;
            }
            set
            {
                Set<PersonViewModel>(ref selectedPerson, value);
            }
        }

        private PartyViewModel selectedParty;
        public PartyViewModel SelectedParty
        {
            get
            {
                return this.selectedParty;
            }
            set
            {
                Set<PartyViewModel>(ref selectedParty, value);
            }
        }

        private ObservableCollection<FilterViewModel> filters;
        public ObservableCollection<FilterViewModel> Filters
        {
            get
            {
                return this.filters;
            }
            set
            {
                Set<ObservableCollection<FilterViewModel>>(ref filters, value);
            }
        }

        private ObservableCollection<PartyViewModel> parties;
        public ObservableCollection<PartyViewModel> Parties
        {
            get
            {
                return this.parties;
            }
            set
            {
                Set<ObservableCollection<PartyViewModel>>(ref parties, value);
            }
        }

        private ObservableCollection<PersonViewModel> people;
        public ObservableCollection<PersonViewModel> People
        {
            get
            {
                return this.people;
            }
            set
            {
                Set<ObservableCollection<PersonViewModel>>(ref people, value);
            }
        }

        private ObservableCollection<PersonViewModel> randomPeople;
        public ObservableCollection<PersonViewModel> RandomPeople
        {
            get
            {
                return this.randomPeople;
            }
            set
            {
                Set<ObservableCollection<PersonViewModel>>(ref randomPeople, value);
            }
        }

        private ObservableCollection<PersonViewModel> following;
        public ObservableCollection<PersonViewModel> Following
        {
            get
            {
                return this.following;
            }
            set
            {
                Set<ObservableCollection<PersonViewModel>>(ref following, value);
            }
        }

        public MainViewModel()
        {
            this.jsonService = GetService<Contracts.IJsonService>(); 
            this.Navigator = GetService<INavigationService>();
            this.NetworkMonitor = GetService<INetworkService>(); 

            this.showAboutInfoCommand = new RelayCommand(ShowAboutInfo, null);
            this.getFiltersCommand = new RelayCommand(GetFilters, null);
            this.getFollowingPeopleCommand = new RelayCommand(GetFollowingPeopleAsync, null);
            this.getRandomPersonCommand = new RelayCommand(GetRandomPeopleAsync, null);
            this.getPartiesCommand = new RelayCommand(GetPartiesAsync, null);
            this.getPeopleByPartyCommand = new RelayCommand(GetPeopleByPartyAsync, null);
        }

        #region ShowAbout
        private ICommand showAboutInfoCommand;
        public ICommand ShowAboutInfoCommand
        {
            get { return this.showAboutInfoCommand; }
        }

        public void ShowAboutInfo()
        {
            Navigator.Navigate<AboutViewModel>();
        }
        #endregion ShowAbout

        #region GetFilters
        private ICommand getFiltersCommand;
        public ICommand GetFiltersCommand
        {
            get { return this.getFiltersCommand; }
        }

        public void GetFilters()
        {
            if (NetworkMonitor.IsNetworkAvailable)
            {
                var result = jsonService.GetFilters();
                ViewModelHelper.SetFilters(this, result);
            }
        }
        #endregion GetFilters

        #region GetFollowingPeople

        private ICommand getFollowingPeopleCommand;
        public ICommand GetFollowingPeopleCommand
        {
            get { return this.getFollowingPeopleCommand; }
        }
        public async void GetFollowingPeopleAsync()
        {
            try
            {
                if (NetworkMonitor.IsNetworkAvailable)
                {
                    var result = await jsonService.GetPeopleAsync(string.Empty);
                    ViewModelHelper.SetPeople(this, result);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        #endregion GetFollowingPeopleCommand

        #region GetPeopleByParty

        private ICommand getPeopleByPartyCommand;
        public ICommand GetPeopleByPartyCommand
        {
            get { return this.getPeopleByPartyCommand; }
        }
        public async void GetPeopleByPartyAsync()
        {
            try
            {
                if (NetworkMonitor.IsNetworkAvailable)
                {
                    var result = await jsonService.GetPeopleByPartyAsync(this.SelectedParty.Id);
                    ViewModelHelper.SetPeople(this, result);
                }
            }
            catch (System.Exception)
            {
                //throw;
            }
        }

        #endregion GetFollowingPeople

        #region GetRandomPeople
        private ICommand getRandomPersonCommand;
        public ICommand GetRandomPersonCommand
        {
            get { return this.getRandomPersonCommand; }
        }

        public void GetRandomPeopleAsync()
        {
            try
            {
                ViewModelHelper.InitilizeRandomPeople(this, 4); //Change limit for parameter
                for (int i = 0; i < 4; i++)
                {
                    LoadRandomPerson(i);
                }       
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LoadRandomPerson(int index)
        {
            Task.Factory.StartNew<Person>(() =>
                {
                    return GetRandomPerson().Result;
                })
                .ContinueWith((antecedant) =>
                {
                    ViewModelHelper.SetRandomPerson(this, antecedant.Result, index);
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async Task<Person> GetRandomPerson()
        {
            Person person = null;
            if (NetworkMonitor.IsNetworkAvailable)
            {
                while (person == null)
                {
                    try
                    {
                        int randomId = GetNewRandomId();
                        var result = await jsonService.GetPersonAsync(randomId);
                        if (result != null)
                        {
                            person = result;
                            loadedRandomPeople.Add(randomId);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            return person;
        }

        private int GetNewRandomId()
        {
            int randomId = randomizer.Next(1, 200); //Change limit for parameter
            while(loadedRandomPeople.Exists(p => p == randomId))
                randomId = randomizer.Next(1, 200);

            return randomId;
        }
        #endregion GetRandomPeople

        #region GetParties
        private ICommand getPartiesCommand;
        public ICommand GetPartiesCommand
        {
            get { return this.getPartiesCommand; }
        }
        public async void GetPartiesAsync()
        {
            try
            {
                if (NetworkMonitor.IsNetworkAvailable)
                {
                    var result = await jsonService.GetPartiesAsync();
                    ViewModelHelper.SetParties(this, result);
                }
            }
            catch (System.Exception)
            {
                //throw;
            }
        }
        #endregion GetParties

        public void Initialize()
        {
            this.GetFollowingPeopleAsync();
            this.GetRandomPeopleAsync();
            this.GetPartiesAsync();
        }
    }
}
