using Autofac;
using CongresoVisible.Models;
using CongresoVisible.Services.Contracts;
using CongresoVisible.ViewModels.Helpers;
using Infrastructure.Common;
using Infrastructure.Common.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Contracts = CongresoVisible.Services.Contracts;
namespace CongresoVisible.ViewModels
{
    public class PartyViewModel : BindableBase
    {
        Contracts.IJsonService jsonService;

        private int id = 0;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                Set<int>(ref id, value);
            }
        }

        private string name = string.Empty;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Set<string>(ref name, value);
            }
        }

        private string logo = string.Empty;
        public string Logo
        {
            get
            {
                return this.logo;
            }
            set
            {
                Set<string>(ref logo, value);
            }
        }

        public ObservableCollection<PersonViewModel> People { get; set; }

        public PartyViewModel()
        {
            this.jsonService = GetService<Contracts.IJsonService>();
            this.Navigator = GetService<INavigationService>();
            this.NetworkMonitor = GetService<INetworkService>();

            this.showPartyDetailsCommand = new RelayCommand(ShowPartyDetailsAsync, null);
        }

        #region ShowPartyDetails
        private ICommand showPartyDetailsCommand;
        public ICommand ShowPartyDetailsCommand
        {
            get { return this.showPartyDetailsCommand; }
        }
        public async void ShowPartyDetailsAsync()
        {
            try
            {
                //MainViewModel main = GetViewModel<MainViewModel>();
                //main.SelectedParty = new PartyViewModel();
                //main.SelectedParty.Name = this.Name;

                //Navigator.Navigate<PartyViewModel>();

                //if (NetworkMonitor.IsNetworkAvailable)
                //{
                //    var result = await jsonService.GetPeopleByPartyAsync(this.Id);
                //    ViewModelHelper.SetPeople(this, result);
                //}
            }
            catch (System.Exception)
            {
                //throw;
            }
        }
        #endregion GetParties
    }
}
