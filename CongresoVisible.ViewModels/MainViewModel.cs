using Autofac;
using CongresoVisible.Services.Contracts;
using CongresoVisible.ViewModels.Helpers;
using Infrastructure.Common;
using Infrastructure.Common.Contracts;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CongresoVisible.ViewModels
{
    public class MainViewModel : BindableBase
    {
        IJsonService jsonService;

        private PersonViewModel selectedPerson;
        public PersonViewModel SelectedPerson
        {
            get
            {
                return this.selectedPerson;
            }
            set
            {
                SetProperty(ref selectedPerson, value);
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
                SetProperty(ref selectedParty, value);
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
                SetProperty(ref filters, value);
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
                SetProperty(ref parties, value);
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
                SetProperty(ref people, value);
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
                SetProperty(ref following, value);
            }
        }

        public MainViewModel(IContainer container)
        {
            this.SetContainer(container);

            this.jsonService = GetService<IJsonService>(); 
            this.Navigator = GetService<INavigationService>();
            this.NetworkMonitor = GetService<INetworkService>(); 
            this.NetworkMonitor.Initialize();

            this.showAboutInfoCommand = new DelegateCommand(ShowAboutInfo, null);
            this.getFiltersCommand = new DelegateCommand(GetFilters, null);
            this.getFollowingPeopleCommand = new DelegateCommand(GetFollowingPeopleAsync, null);
            this.getRandomPeopleCommand = new DelegateCommand(GetRandomPeopleAsync, null);
            this.getPartiesCommand = new DelegateCommand(GetPartiesAsync, null);
            this.getPeopleByPartyCommand = new DelegateCommand(GetPeopleByPartyAsync, null);
        }

        #region ShowAbout
        private DelegateCommand showAboutInfoCommand;
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
            if (NetworkMonitor.IsNetworkAvailable)
            {
                var result = await jsonService.GetPeopleAsync(string.Empty);
                ViewModelHelper.SetPeople(this, result);
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
            if (NetworkMonitor.IsNetworkAvailable)
            {
                var result = await jsonService.GetPeopleByPartyAsync(this.SelectedParty.Id);
                ViewModelHelper.SetPeople(this, result);
            }
        }

        #endregion GetFollowingPeople

        #region GetRandomPeople
        private ICommand getRandomPeopleCommand;
        public ICommand GetRandomPeopleCommand
        {
            get { return this.getRandomPeopleCommand; }
        }
        public async void GetRandomPeopleAsync()
        {
            if (NetworkMonitor.IsNetworkAvailable)
            {
                var result = await jsonService.GetPeopleAsync(string.Empty);
                ViewModelHelper.SetRandomPeople(this, result);
            }
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
            if (NetworkMonitor.IsNetworkAvailable)
            {
                var result = await jsonService.GetPartiesAsync();
                ViewModelHelper.SetParties(this, result);
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
