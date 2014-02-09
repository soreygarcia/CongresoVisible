using Autofac;
using CongresoVisible.Services.Contracts;
using CongresoVisible.ViewModels.Helpers;
using GalaSoft.MvvmLight.Command;
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
                Set <ObservableCollection<PersonViewModel>>(ref people, value);
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
            this.jsonService = GetService<IJsonService>(); 
            this.Navigator = GetService<INavigationService>();
            this.NetworkMonitor = GetService<INetworkService>(); 
            this.NetworkMonitor.Initialize();

            this.showAboutInfoCommand = new RelayCommand(ShowAboutInfo, null);
            this.getFiltersCommand = new RelayCommand(GetFilters, null);
            this.getFollowingPeopleCommand = new RelayCommand(GetFollowingPeopleAsync, null);
            this.getRandomPeopleCommand = new RelayCommand(GetRandomPeopleAsync, null);
            this.getPartiesCommand = new RelayCommand(GetPartiesAsync, null);
            this.getPeopleByPartyCommand = new RelayCommand(GetPeopleByPartyAsync, null);

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        #region ShowAbout
        private RelayCommand showAboutInfoCommand;
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
