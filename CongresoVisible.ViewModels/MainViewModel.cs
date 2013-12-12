using CongresoVisible.Contracts.Services;
using CongresoVisible.Contracts.ViewModels;
using CongresoVisible.Contracts.ViewModels.Common;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CongresoVisible.ViewModels
{
    public class MainViewModel : BindableBase, IMainViewModel
    {
        IJsonService jsonService;

        private IPersonViewModel selectedPerson;
        public IPersonViewModel SelectedPerson
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

        private ObservableCollection<IFilterViewModel> filters;
        public ObservableCollection<IFilterViewModel> Filters
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

        private ObservableCollection<IPartyViewModel> parties;
        public ObservableCollection<IPartyViewModel> Parties
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

        private ObservableCollection<IPersonViewModel> people;
        public ObservableCollection<IPersonViewModel> People
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

        private ObservableCollection<IPersonViewModel> following;
        public ObservableCollection<IPersonViewModel> Following
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

        public MainViewModel()
        {
            this.showAboutInfoCommand = new DelegateCommand(ShowAboutInfo, null);
            this.getFiltersCommand = new DelegateCommand(GetFilters, null);
            this.getFollowingPeopleCommand = new DelegateCommand(GetFollowingPeople, null);
            this.getRandomPeopleCommand = new DelegateCommand(GetRandomPeople, null);
            this.getPartiesCommand = new DelegateCommand(GetParties, null);

            jsonService = GetService<IJsonService>();
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
                jsonService.GetFilters();
            }
        }
        #endregion GetFilters

        #region GetFollowingPeople

        private ICommand getFollowingPeopleCommand;
        public ICommand GetFollowingPeopleCommand
        {
            get { return this.getFollowingPeopleCommand; }
        }
        public void GetFollowingPeople()
        {
            if (NetworkMonitor.IsNetworkAvailable)
            {

            }
        }

        #endregion GetFollowingPeople

        #region GetRandomPeople
        private ICommand getRandomPeopleCommand;
        public ICommand GetRandomPeopleCommand
        {
            get { return this.getRandomPeopleCommand; }
        }
        public void GetRandomPeople()
        {
            if (NetworkMonitor.IsNetworkAvailable)
            {

            }
        }
        #endregion GetRandomPeople

        #region GetParties
        private ICommand getPartiesCommand;
        public ICommand GetPartiesCommand
        {
            get { return this.getPartiesCommand; }
        }
        public void GetParties()
        {
            if (NetworkMonitor.IsNetworkAvailable)
            {

            }
        }
        #endregion GetParties
    }
}
